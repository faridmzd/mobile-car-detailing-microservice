using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Responses
{
    public record CreateCustomerCommandResponse(Guid Id, string PassportNo, string Name, DateTime CreatedAt, DateTime UpdatedAt);
    
}
