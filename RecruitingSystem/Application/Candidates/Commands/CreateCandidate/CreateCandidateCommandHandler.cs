using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, CandidateCreatedVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public CreateCandidateCommandHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateCreatedVm> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = _mapper.Map<Candidate>(request);
            await _context.Candidates.AddAsync(candidateEntity);
            if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
            {
                throw new ResourceManipulationException("Error during adding Candidate resource");
            }

            return _mapper.Map<CandidateCreatedVm>(candidateEntity);
        }
    }
}
