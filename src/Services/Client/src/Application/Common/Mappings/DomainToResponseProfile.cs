using AutoMapper;
using Client.Application.Customers.Responses;
using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Mappings
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile() 
        {
            CreateMap<Customer, CreateCustomerCommandResponse>();
        }
    }
}
