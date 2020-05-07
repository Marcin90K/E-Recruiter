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
            var candidateEntity = await _context.Candidates.Where(c => c.Id == request.Id)
                .Include(c => c.BasicData).ThenInclude(d => d.PersonBasicData)
                .Include(c => c.BasicData).ThenInclude(d => d.Address)
                .Include(c => c.CandidateJobOffers)
                .Include(c => c.Educations)
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync();
            //var candidateEntity = _context.Candidates.SingleOrDefault(c => c.Id == request.Id);  //Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            
            if (candidateEntity == null)
            {
                candidateEntity = _mapper.Map<Candidate>(request);
                candidateEntity.Id = request.Id;
                await _context.Candidates.AddAsync(candidateEntity);
                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during upserting Candidates resource id {request.Id}");
                }

                return _mapper.Map<CandidateUpdatedVm>(candidateEntity);
            }
            else
            {
                var candidateToUpdate = _mapper.Map<UpdateCandidateCommand, Candidate>(request, candidateEntity);//, candidateEntity);

                //candidateEntity.Id = request.Id;
                //candidateEntity.BasicData = request.CandidateBasicData;
                //candidateEntity.BasicData.CandidateId = request.Id;
                //candidateEntity.BasicData.Candidate = request.CandidateBasicData.Candidate;

                //candidateEntity.BasicData.Address = request.CandidateBasicData.Address;
                //candidateEntity.BasicData.PersonBasicData = request.CandidateBasicData.PersonBasicData;
                //candidateEntity.Educations = request.Educations;
                //candidateEntity.Experiences = request.Experiences;
                //candidateEntity.ExpectedSalary = request.ExpectedSalary;

                _context.Candidates.Update(candidateToUpdate);
                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during updating resource id: {request.Id}");
                }

                return _mapper.Map<CandidateUpdatedVm>(candidateEntity);
            }
        }
    }
}
