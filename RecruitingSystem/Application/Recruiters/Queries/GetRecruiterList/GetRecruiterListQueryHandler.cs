using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.Recruiter;
using Application.Common.Utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recruiters.Queries.GetRecruiterList
{
    public class GetRecruiterListQueryHandler : IRequestHandler<GetRecruiterListQuery, RecruiterListVm>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetRecruiterListQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecruiterListVm> Handle(GetRecruiterListQuery request, CancellationToken cancellationToken)
        {
            var parameters = request.ResourceParameters;
            IList<RecruiterDTO> recruiters;

            if (parameters.Search != null)
            {
                var recruitersSearched = ApplySearch(parameters.Search);
                var recruitersPaged = new PagedList<Recruiter>(recruitersSearched, parameters.PageNumber, parameters.PageSize);
                recruiters = _mapper.Map<IList<RecruiterDTO>>(recruitersPaged);
            }
            else
            {
                var recruitersFromDb = await _context.Recruiters
                    .Include(r => r.Manager)
                    .Include(r => r.OwnedJobOffers)
                    .ProjectTo<RecruiterDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                recruiters = new PagedList<RecruiterDTO>(recruitersFromDb, parameters.PageNumber, parameters.PageSize);
            }

            if (recruiters == null)
            {
                throw new ResourceNotFoundException($"Not found any Recruiters");
            }

            var recruitersResult = new RecruiterListVm()
            {
                Recruiters = recruiters,
                Pagination = new Pagination(parameters.PageNumber, parameters.PageSize, recruiters.Count)
            };

            return recruitersResult;
        }

        private IEnumerable<Recruiter> ApplySearch(string searchQuery)
        {
            return _context.Recruiters
                .Include(r => r.Manager)
                .Include(r => r.OwnedJobOffers)
                .AsEnumerable()
                .Where(r => r.Manager.Id.ToString().ToLowerInvariant() == searchQuery.ToLowerInvariant());
        }
    }
}
