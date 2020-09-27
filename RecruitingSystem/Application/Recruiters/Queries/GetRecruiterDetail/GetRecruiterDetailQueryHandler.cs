using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.Recruiter;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recruiters.Queries.GetRecruiterDetail
{
    public class GetRecruiterDetailQueryHandler : IRequestHandler<GetRecruiterDetailQuery, RecruiterDTO>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetRecruiterDetailQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecruiterDTO> Handle(GetRecruiterDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Recruiters.Where(r => r.Id == request.Id)
                .Include(r => r.Manager)
                .Include(r => r.OwnedJobOffers)
                .Include(r => r.Employee).ThenInclude(e => e.PersonBasicData)
                .FirstOrDefault();

            if (entity == null)
            {
                throw new ResourceNotFoundException($"Not found Recruiter with id: {request.Id}");
            }

            return _mapper.Map<RecruiterDTO>(entity);
        }
    }
}
