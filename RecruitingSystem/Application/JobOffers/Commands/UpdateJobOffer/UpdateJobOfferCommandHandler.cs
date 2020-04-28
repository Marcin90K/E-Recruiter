using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobOffers.Commands.UpdateJobOffer
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, JobOfferUpdatedVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public UpdateJobOfferCommandHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobOfferUpdatedVm> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOfferEntity = await _context.JobOffers.Where(j => j.Id == request.Id).FirstOrDefaultAsync();
            if (jobOfferEntity == null)
            {
                jobOfferEntity = _mapper.Map<JobOffer>(request);
                jobOfferEntity.Id = request.Id;
                jobOfferEntity.DateOfAdding = DateTime.Now;

                await _context.JobOffers.AddAsync(jobOfferEntity);
                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException("Error during upserting Job offer.");
                }

                return _mapper.Map<JobOfferUpdatedVm>(jobOfferEntity);
            }
            else
            {
                var jobOfferForUpdate = _mapper.Map(request, jobOfferEntity);
                _context.JobOffers.Update(jobOfferForUpdate);

                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during updating resource id: {request.Id}");
                }

                return _mapper.Map<JobOfferUpdatedVm>(jobOfferForUpdate);
            }
        
        }
    }
}
