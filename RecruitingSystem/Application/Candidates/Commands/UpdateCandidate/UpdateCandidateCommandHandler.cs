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
                .Include(c => c.Educations).ThenInclude(e => e.Candidate)
                .Include(c => c.Experiences).ThenInclude(e => e.Candidate)
                .FirstOrDefaultAsync();

            if (candidateEntity == null)
            {
                candidateEntity = _mapper.Map<Candidate>(request);
                candidateEntity.Id = request.Id;
                request.Educations.ToList().ForEach(ed =>
                {
                    candidateEntity.Educations.Add(
                        new Education()
                        {
                            CourseName = ed.CourseName,
                            SchoolName = ed.SchoolName,
                            StartDate = ed.StartDate,
                            EndDate = ed.EndDate
                        }
                    );
                });
                request.Experiences.ToList().ForEach(ex =>
                {
                    candidateEntity.Experiences.Add(
                        new Experience()
                        {
                            CompanyName = ex.CompanyName,
                            Duties = ex.Duties,
                            JobTitle = ex.JobTitle,
                            StartDate = ex.StartDate,
                            EndDate = ex.EndDate
                        }
                        );
                });


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
                int i = 0;
                request.Educations.ToList().ForEach(ed =>
                {
                    var entity = candidateEntity.Educations.ElementAt(i);
                    entity.CourseName = ed.CourseName;
                    entity.SchoolName = ed.SchoolName;
                    entity.StartDate = ed.StartDate;
                    entity.EndDate = ed.EndDate;
                    i++;
                });

                int j = 0;
                request.Experiences.ToList().ForEach(ex =>
                {
                    var entity = candidateEntity.Experiences.ElementAt(j);
                    entity.CompanyName = ex.CompanyName;
                    entity.Duties = ex.Duties;
                    entity.JobTitle = ex.JobTitle;
                    entity.StartDate = ex.StartDate;
                    entity.EndDate = ex.EndDate;
                    j++;
                });

                //_context.Candidates.Update(candidateToUpdate);

                if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
                {
                    throw new ResourceManipulationException($"Error during updating resource id: {request.Id}");
                }

                return _mapper.Map<CandidateUpdatedVm>(candidateToUpdate);
            }
        }
    }
}
