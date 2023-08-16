using AutoMapper;
using Client.Application.Common.Errors;
using Client.Application.Common.Interfaces;
using Client.Application.Customers.Responses;
using Client.Domain.Entities;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Commands
{
    public record CreateCustomerCommand(string Name, string PassportNo) : IRequest<Result<CreateCustomerCommandResponse>>;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CreateCustomerCommandResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            //checking if customer with given PassportNo already exists


           var customer =  _context.Customers.FirstOrDefault(customer => customer.PassportNo == request.PassportNo);

            if (customer == null) { return Result.Fail<CreateCustomerCommandResponse>(new DuplicatePassportNoError()); }

            // else create customer

            var newCustomer = _mapper.Map<Customer>(request);

            //TODO fix it, adding params manually

            newCustomer.Id = new Guid();
            newCustomer.CreatedAt = DateTime.UtcNow;
            newCustomer.UpdatedAt = DateTime.UtcNow;

          
            _context.Customers.Add(newCustomer);

            await _context.SaveChangesAsync(cancellationToken);

            

            return _mapper.Map<CreateCustomerCommandResponse>(newCustomer);
        }
    }
}
