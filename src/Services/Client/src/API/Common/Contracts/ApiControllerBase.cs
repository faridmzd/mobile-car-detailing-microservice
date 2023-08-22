using Client.Application.Common.HTTP;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Client.Application.Common.Errors;

namespace Client.API.Controllers
{
    [Route("")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public  IActionResult Problem(List<IError> errors)
        {
            var firstError =  errors.First() as ErrorBase;

            ArgumentNullException.ThrowIfNull(firstError);

                return new ObjectResult(new ProblemDetails
                {
                    Status = firstError.StatusCode,
                    Extensions = { { nameof(firstError.Metadata), firstError.Metadata } }
                });

        }

    }
}
