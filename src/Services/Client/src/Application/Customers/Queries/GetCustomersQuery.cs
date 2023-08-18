using AutoMapper;
using Client.Application.Common.Interfaces;
using Client.Application.Customers.Responses;
using Client.Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Queries
{
    public record GetCustomersQuery : IRequest<IEnumerable<GetCustomerQueryResponse>>;

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<GetCustomerQueryResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCustomerQueryResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers =  await _context.Customers.ToListAsync(cancellationToken);

           var result = _mapper.Map<IEnumerable<GetCustomerQueryResponse>>(customers);
            
            return result;

        }


    }


}
