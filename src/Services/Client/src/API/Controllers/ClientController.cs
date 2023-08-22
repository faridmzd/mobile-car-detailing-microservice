using Client.API.Common.Contracts;
using Client.Application.Customers.Commands;
using Client.Application.Customers.Queries;
using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{

    public class ClientController : ApiControllerBase
    {
        [HttpGet(ApiRoutes.Customer.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetCustomersQuery());

            return result.Any() ? Ok(result) : NoContent();

        }

        [HttpGet(ApiRoutes.Customer.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetCustomerQuery(id));

            return result switch
            {
                { IsSuccess: true } => Ok(result.Value),
                { IsFailed: true } => Problem(result.Errors),
                _ => null!
            };

        }

        [HttpPost(ApiRoutes.Customer.Add)]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {

            var result = await Mediator.Send(command);




            return result switch
            {
                { IsSuccess: true } => Ok(result.Value),
                { IsFailed: true } => Problem(result.Errors),
                _ => null!
            };

        }

        [HttpPut(ApiRoutes.Customer.Update)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCustomerCommandRequest request)
        {
            var command = new UpdateCustomerCommand(id, request.PassportNo, request.Name);

            var result = await Mediator.Send(command);

            return result switch
            {
                { IsSuccess: true } => Ok(result.Value),
                { IsFailed: true } => Problem(result.Errors),
                _ => null!
            };
        }

        [HttpDelete(ApiRoutes.Customer.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteCustomerCommand(id)); ;

            return result switch
            {
                { IsSuccess: true } => NoContent(),
                { IsFailed: true } => Problem(result.Errors),
                _ => null!
            };

        }
    }
}
