using Application.Common.Interfaces;
using Application.Common.Models.JobOffer;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobOffers.Commands.CreateJobOffer
{
    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, JobOfferDTO>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IReqruitingSystemDbContext context, 
            IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<JobOfferDTO> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOfferEntity = _mapper.Map<JobOffer>(request);
            jobOfferEntity.DateOfAdding = DateTime.Now;

            _context.JobOffers.Add(jobOfferEntity);
            await _context.SaveChangesAsync(cancellationToken);

            var jobOfferToReturn = _mapper.Map<JobOfferDTO>(jobOfferEntity);
            return jobOfferToReturn;
        }
    }
}
