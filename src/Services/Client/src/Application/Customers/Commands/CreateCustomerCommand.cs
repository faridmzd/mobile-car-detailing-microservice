using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            

            var newCustomer = _mapper.Map<Customer>(request);

            //TODO fix it, adding params manually

            newCustomer.Id = new Guid();
            newCustomer.CreatedAt = DateTime.UtcNow;
            newCustomer.UpdatedAt = DateTime.UtcNow;

          
            _context.Customers.Add(newCustomer);

            await _context.SaveChangesAsync(cancellationToken);

            

            return _mapper.Map<CreateCustomerResponse>(newCustomer);
        }
    }
}
