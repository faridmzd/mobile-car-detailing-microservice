using Client.Application.Customers.Responses;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Application.Common.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Client.Application.Common.Errors;

namespace Client.Application.Customers.Commands
{
    public record UpdateCustomerCommandRequest(string PassportNo, string Name);

    public record UpdateCustomerCommand(Guid Id, string PassportNo, string Name) : IRequest<Result<UpdateCustomerCommandResponse>>
    {

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<UpdateCustomerCommandResponse>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<UpdateCustomerCommandResponse>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == command.Id);

                if (customer == null) return Result.Fail(new NotFoundError(command.Id));

                customer.Name = command.Name ?? customer.Name;
                customer.PassportNo = command.PassportNo ?? customer.PassportNo;
                customer.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync(cancellationToken);

                return Result.Ok(_mapper.Map<UpdateCustomerCommandResponse>(customer));
            }
        }

    }
}
