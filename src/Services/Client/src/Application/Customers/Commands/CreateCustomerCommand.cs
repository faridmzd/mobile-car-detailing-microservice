using Client.Application.Common.Interfaces;
using Client.Application.Customers.Responses;
using Client.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Commands
{
    public record CreateCustomerCommand(string Name) : IRequest<CreateCustomerResponse>;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer newCustomer = new()
            {
                Id = new Guid(),
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow

            };

            _context.Customers.Add(newCustomer);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerResponse(
                newCustomer.Id, 
                newCustomer.Name,
                newCustomer.CreatedAt, 
                newCustomer.UpdatedAt);
           
        }
    }
}
