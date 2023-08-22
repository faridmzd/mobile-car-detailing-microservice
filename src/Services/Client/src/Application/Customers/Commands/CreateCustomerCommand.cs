using AutoMapper;
using Client.Application.Common.Errors;
using Client.Application.Common.Interfaces;
using Client.Application.Customers.Responses;
using Client.Domain.Entities;
using FluentResults;
using FluentValidation;
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

        public async Task<Result<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {

            //checking if customer with given PassportNo already exists


           var customer =  _context.Customers.FirstOrDefault(customer => customer.PassportNo == command.PassportNo);

            if (customer is not null) { return Result.Fail<CreateCustomerCommandResponse>(new DuplicatePassportNoError(customer.PassportNo)); }

            // else create customer

            var newCustomer = _mapper.Map<Customer>(command);
          
            _context.Customers.Add(newCustomer);

            await _context.SaveChangesAsync(cancellationToken);

            

            return  Result.Ok(_mapper.Map<CreateCustomerCommandResponse>(newCustomer));
        }
    }

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty().WithMessage("Name can't be empty!")
                .NotNull();

            RuleFor(v => v.PassportNo)
                .MinimumLength(9)
                .NotEmpty()
                .NotNull();
        }
    }
}
