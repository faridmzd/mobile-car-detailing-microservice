using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Client.Application.Common.Behavior;
using Client.Application.Customers.Commands;
using FluentResults;
using Client.Application.Customers.Responses;

namespace Client.Application;


    public static class ConfigureServices
{

    //.AddBehavior<IPipelineBehavior<
    //                CreateCustomerCommand, Result<CreateCustomerCommandResponse>>,
    //            ValidationBehavior<CreateCustomerCommand, CreateCustomerCommandResponse>>();

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            });

        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }

