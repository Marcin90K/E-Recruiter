using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Domain.Entities;
using Application.Common.Models.JobOffer;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Application.Common.Utilities;
using Application.Common.Exceptions;

namespace Application.JobOffers.Queries.GetJobOfferList
{
    public class GetJobOfferListQueryHandler : IRequestHandler<GetJobOfferListQuery, JobOfferListVm>
    {
        private IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetJobOfferListQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobOfferListVm> Handle(GetJobOfferListQuery request, CancellationToken cancellationToken)
        {
            var parameters = request.ResourceParameters;
            IList<JobOfferDTO> jobOffers = null;

            if (parameters.Search != null)
            {
                var jobOffersSearched = ApplySearch(parameters.Search);
                var jobOffersPaged = new PagedList<JobOffer>(jobOffersSearched, parameters.PageNumber, parameters.PageSize);

                jobOffers = _mapper.Map<IList<JobOfferDTO>>(jobOffersPaged);
            }
            else
            {
                var jobOffersFromDb = await _context.JobOffers
                    .Include(j => j.JobPosition)
                    .Include(j => j.Owner)
                    .ProjectTo<JobOfferDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                jobOffers = new PagedList<JobOfferDTO>(jobOffersFromDb, parameters.PageNumber, parameters.PageSize);    
            }

            if (jobOffers == null)
            {
                throw new ResourceNotFoundException("Not found any Job Offers.");
            }

            var jobOffersResult = new JobOfferListVm
            {
                JobOffers = jobOffers,
                Pagination = new Pagination(parameters.PageNumber, parameters.PageSize, jobOffers.Count)
            };

            return jobOffersResult;
        }



        private IEnumerable<JobOffer> ApplySearch(string searchQuery)
        {
            return _context.JobOffers
                .Include(j => j.JobPosition)
                .Include(j => j.Owner)
                .AsEnumerable()
                .Where(j => j.JobPosition.Name.ToLowerInvariant().Contains(searchQuery) ||
                    j.Owner.EmployeeId.ToString().ToLowerInvariant().Contains(searchQuery) ||
                    j.Requirements.ToLowerInvariant().Contains(searchQuery));
        }


    }
}
