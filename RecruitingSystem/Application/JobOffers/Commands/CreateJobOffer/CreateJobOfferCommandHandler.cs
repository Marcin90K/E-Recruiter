using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobOffers.Commands.CreateJobOffer
{
    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, JobOfferCreatedVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IReqruitingSystemDbContext context, 
               IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobOfferCreatedVm> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOfferEntity = _mapper.Map<JobOffer>(request);
            jobOfferEntity.DateOfAdding = DateTime.Now;

            await _context.JobOffers.AddAsync(jobOfferEntity);
            if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
            {
                throw new ResourceManipulationException("Error during JobOffer creating.");
            }

            var jobOfferToReturn = _mapper.Map<JobOfferCreatedVm>(jobOfferEntity);
            return jobOfferToReturn;
        }
    }
}
