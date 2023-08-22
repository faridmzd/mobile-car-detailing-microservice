using Client.Application.Customers.Responses;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Commands
{
    public record UpdateCustomerCommand(string PassportNo, string Name) : IRequest<Result<UpdateCustomerCommandResponse>>
    {

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand,Result<UpdateCustomerCommandResponse>>
        {

            public async Task<Result<UpdateCustomerCommandResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
               



            }
        }

    }
}
