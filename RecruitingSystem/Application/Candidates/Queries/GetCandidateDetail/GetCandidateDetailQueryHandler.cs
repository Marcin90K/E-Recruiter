using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.Candidate;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Candidates.Queries.GetCandidateDetail
{
    public class GetCandidateDetailQueryHandler : IRequestHandler<GetCandidateDetailQuery, CandidateDTO>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidateDetailQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateDTO> Handle(GetCandidateDetailQuery request, CancellationToken cancellationToken)
        {
            var candidateEntity = await _context.Candidates.Where(c => c.Id == request.Id)
                .Include(c => c.BasicData).ThenInclude(d => d.PersonBasicData)
                .Include(c => c.BasicData).ThenInclude(d => d.Address)
                .Include(c => c.CandidateJobOffers)
                .Include(c => c.Educations)
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync();

            if (candidateEntity == null)
            {
                throw new ResourceNotFoundException($"Not found candidate with id: {request.Id}");
            }

            return _mapper.Map<CandidateDTO>(candidateEntity);
        }
    }
}
