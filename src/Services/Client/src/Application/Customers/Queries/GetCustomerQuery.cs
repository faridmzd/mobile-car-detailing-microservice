using AutoMapper;
using Client.Application.Common.Errors;
using Client.Application.Common.Interfaces;
using Client.Application.Customers.Responses;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Client.Application.Customers.Queries;

    public record GetCustomerQuery(Guid Id) : IRequest<Result<GetCustomerQueryResponse>>;


    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Result<GetCustomerQueryResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomerQueryResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return customer is null
                 ? Result.Fail(new NotFoundError(request.Id))
                 : Result.Ok(_mapper.Map<GetCustomerQueryResponse>(customer));
        }
    }



