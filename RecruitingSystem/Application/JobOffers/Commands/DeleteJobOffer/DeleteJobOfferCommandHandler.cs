using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobOffers.Commands.DeleteJobOffer
{
    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand>
    {
        private readonly IReqruitingSystemDbContext _context;

        public DeleteJobOfferCommandHandler(IReqruitingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOfferEntity = await _context.JobOffers.FindAsync(request.Id);
            if (jobOfferEntity == null)
            {
                throw new ResourceNotFoundException($"Resource with id: {request.Id} doesn't exist in database");
            }

            _context.JobOffers.Remove(jobOfferEntity);
            if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
            {
                throw new ResourceManipulationException("Error during resource removing");
            }

            return Unit.Value;
        }
    }
}
