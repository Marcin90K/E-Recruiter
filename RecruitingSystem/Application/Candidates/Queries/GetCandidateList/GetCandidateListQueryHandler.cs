using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.Candidate;
using Application.Common.Utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Candidates.Queries.GetCandidateList
{
    public class GetCandidateListQueryHandler : IRequestHandler<GetCandidateListQuery, GetCandidateListVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidateListQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCandidateListVm> Handle(GetCandidateListQuery request, CancellationToken cancellationToken)
        {
            var parameters = request.ResourceParameters;
            IList<CandidateDTO> candidates = null;

            if (parameters.Search != null)
            {
                var candidatesSearched = ApplySearch(parameters.Search);
                var candidatesPaged = new PagedList<Candidate>(candidatesSearched, parameters.PageNumber, parameters.PageSize);
                candidates = _mapper.Map<IList<CandidateDTO>>(candidatesPaged);
            }
            else
            {
                var candidatesFromDb = await _context.Candidates
                    .Include(c => c.BasicData).ThenInclude(d => d.PersonBasicData)
                    .Include(c => c.BasicData).ThenInclude(d => d.Address)
                    .Include(c => c.CandidateJobOffers)
                    .Include(c => c.Educations)
                    .Include(c => c.Experiences)
                    .ProjectTo<CandidateDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                candidates = new PagedList<CandidateDTO>(candidatesFromDb, parameters.PageNumber, parameters.PageSize);
            }

            if (candidates == null)
            {
                throw new ResourceNotFoundException($"Not found any Candidates");
            }

            var candidatesResult = new GetCandidateListVm()
            {
                Cadidates = candidates,
                Pagination = new Pagination(parameters.PageNumber, parameters.PageSize, candidates.Count)
            };

            return candidatesResult;
        }

        private IEnumerable<Candidate> ApplySearch(string searchQuery)
        {
            return _context.Candidates
                .Include(c => c.BasicData).ThenInclude(d => d.PersonBasicData)
                .Include(c => c.BasicData).ThenInclude(d => d.Address)
                .Include(c => c.CandidateJobOffers)
                .Include(c => c.Educations)
                .Include(c => c.Experiences)
                .AsEnumerable()
                .Where(c => c.BasicData.PersonBasicData.LastName == searchQuery
                  || c.BasicData.PersonBasicData.FirstName == searchQuery);
        }
    }
}
