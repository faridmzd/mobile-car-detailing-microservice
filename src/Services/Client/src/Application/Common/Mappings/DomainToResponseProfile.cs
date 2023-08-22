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
            CreateMap<Customer, CreateCustomerCommandResponse>()
                .ForCtorParam(nameof(CreateCustomerCommandResponse.Id), c => c.MapFrom(src => src.Id))
                .ForCtorParam(nameof(CreateCustomerCommandResponse.PassportNo), c => c.MapFrom(src => src.PassportNo))
                .ForCtorParam(nameof(CreateCustomerCommandResponse.Name), c => c.MapFrom(src => src.Name))
                .ForCtorParam(nameof(CreateCustomerCommandResponse.CreatedAt), c => c.MapFrom(src => src.CreatedAt))
                .ForCtorParam(nameof(CreateCustomerCommandResponse.UpdatedAt), c => c.MapFrom(src => src.UpdatedAt));


            CreateMap<Customer, GetCustomerQueryResponse>()
                .ForCtorParam(nameof(GetCustomerQueryResponse.Id), c => c.MapFrom(src => src.Id))
                .ForCtorParam(nameof(GetCustomerQueryResponse.PassportNo), c => c.MapFrom(src => src.PassportNo))
                .ForCtorParam(nameof(GetCustomerQueryResponse.Name), c => c.MapFrom(src => src.Name))
                .ForCtorParam(nameof(GetCustomerQueryResponse.CreatedAt), c => c.MapFrom(src => src.CreatedAt))
                .ForCtorParam(nameof(GetCustomerQueryResponse.UpdatedAt), c => c.MapFrom(src => src.UpdatedAt));

            CreateMap<Customer, UpdateCustomerCommandResponse>()
                .ForCtorParam(nameof(UpdateCustomerCommandResponse.Id), c => c.MapFrom(src => src.Id))
                .ForCtorParam(nameof(UpdateCustomerCommandResponse.PassportNo), c => c.MapFrom(src => src.PassportNo))
                .ForCtorParam(nameof(UpdateCustomerCommandResponse.Name), c => c.MapFrom(src => src.Name))
                .ForCtorParam(nameof(UpdateCustomerCommandResponse.CreatedAt), c => c.MapFrom(src => src.CreatedAt))
                .ForCtorParam(nameof(UpdateCustomerCommandResponse.UpdatedAt), c => c.MapFrom(src => src.UpdatedAt));

        }
    }
}
