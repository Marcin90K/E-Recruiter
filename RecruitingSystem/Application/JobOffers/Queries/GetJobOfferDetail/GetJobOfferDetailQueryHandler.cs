using Application.Common.Interfaces;
using Application.Common.Models.JobOffer;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobOffers.Queries.GetJobOfferDetail
{
    public class GetJobOfferDetailQueryHandler : IRequestHandler<GetJobOfferDetailQuery, JobOfferDTO>
    {
        private readonly IReqruitingSystemDbContext _context;
        private readonly IMapper _mapper;

        public GetJobOfferDetailQueryHandler(IReqruitingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobOfferDTO> Handle(GetJobOfferDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.JobOffers.Where(j => j.Id == request.Id).FirstOrDefault();

            if (entity == null)
            {
                throw new Exception("Not found Job offer with given Id");
            }

            return _mapper.Map<JobOfferDTO>(entity);
        }
    }
}
