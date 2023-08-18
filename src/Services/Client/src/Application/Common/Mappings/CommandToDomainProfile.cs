using AutoMapper;
using Client.Application.Customers.Commands;
using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Mappings
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, m => m.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, m => m.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, m => m.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
