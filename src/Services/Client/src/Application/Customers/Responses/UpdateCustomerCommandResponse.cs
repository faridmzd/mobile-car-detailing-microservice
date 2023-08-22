﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Customers.Responses;

    public record UpdateCustomerCommandResponse(Guid Id, string Name, string PassportNo, DateTime CreatedAt, DateTime UpdatedAt);
    

