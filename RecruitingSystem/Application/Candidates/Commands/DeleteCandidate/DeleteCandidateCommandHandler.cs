using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
    {
        private readonly IReqruitingSystemDbContext _context;

        public DeleteCandidateCommandHandler(IReqruitingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = await _context.Candidates.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (candidateEntity == null)
            {
                throw new ResourceManipulationException($"Resource with id: {request.Id} doesn't exist.");
            }

            _context.Candidates.Remove(candidateEntity);
            if (!(await _context.SaveChangesAsync(cancellationToken) > 0))
            {
                throw new ResourceManipulationException($"Error during removing resource with id: {request.Id}");
            }

            return Unit.Value;
        }
    }
}
