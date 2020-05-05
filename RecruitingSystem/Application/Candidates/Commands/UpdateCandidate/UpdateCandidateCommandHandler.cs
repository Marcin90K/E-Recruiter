using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, CandidateUpdatedVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCandidateCommandHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateUpdatedVm> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = await _context.Candidates.AsNoTracking().Where(c => c.Id == request.EntityId).FirstOrDefaultAsync();
            
            if (candidateEntity == null)
            {
                candidateEntity = _mapper.Map<Candidate>(request);
                candidateEntity.Id = request.EntityId;
                await _context.Candidates.AddAsync(candidateEntity);
                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during upserting Candidates resource id {request.EntityId}");
                }

                return _mapper.Map<CandidateUpdatedVm>(candidateEntity);
            }
            else
            {
                var candidateToUpdate = _mapper.Map(request, candidateEntity);
                
                _context.Candidates.Update(candidateToUpdate);
                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during updating resource id: {request.EntityId}");
                }

                return _mapper.Map<CandidateUpdatedVm>(candidateToUpdate);
            }
        }
    }
}
