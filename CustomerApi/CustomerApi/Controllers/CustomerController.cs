using CustomerApi.Commands;
using CustomerApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            AddCustomerCommand command = new()
            {
                Name = customer.Name,
                Email = customer.Email,
                HasLoyaltyMembership = customer.HasLoyaltyMembership,
                Phone = customer.Phone
            };
            var newCustomer = mediator.Send(command);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return BadRequest();
        }
    }
}
