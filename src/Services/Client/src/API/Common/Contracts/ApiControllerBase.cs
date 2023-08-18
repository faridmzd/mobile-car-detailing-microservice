using Client.Application.Common.HTTP;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Client.API.Common.Contracts
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public IActionResult Problem(List<IError> errors)
        {
            var firstError = errors.First();
          
                return (IActionResult)Results.Problem(

                    statusCode: firstError.HasMetadataKey(HttpContextItemKeys.StatusCode)
                    ? (int)(firstError.Metadata[HttpContextItemKeys.StatusCode]) : (int)HttpStatusCode.Conflict,

                    title: firstError.Message
                    );

            
        }
    }
}
