using CustomerApi.Commands;
using CustomerApi.Models;
using CustomerApi.Queries;
using CustomerApi.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var validator = new CustomerValidator();
            var valResult = validator.Validate(customer);
            if (!valResult.IsValid) 
            {
                return BadRequest(valResult.Errors);
            }

            AddCustomerCommand command = new()
            {
                Name = customer.Name,
                Email = customer.Email,
                HasLoyaltyMembership = customer.HasLoyaltyMembership,
                Phone = customer.Phone
            };
            var newCustomer = await mediator.Send(command);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return BadRequest();
        }
    }
}
