using Client.API.Common.Contracts;
using Client.Application.Customers.Commands;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{

    public class ClientController : ApiControllerBase
    {
        [HttpGet(ApiRoutes.Customer.GetAll)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet(ApiRoutes.Customer.Get)]
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete(ApiRoutes.Customer.Delete)]
        public void Delete(int id)
        {
        }
    }
}
