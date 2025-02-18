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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            Customer? customer = await mediator.Send(new GetCustomerByIdQuery(id));
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
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

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            var validator = new CustomerValidator();
            var valResult = validator.Validate(customer);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Errors);
            }
            UpdateCustomerCommand command = new()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                HasLoyaltyMembership = customer.HasLoyaltyMembership,
                Phone = customer.Phone
            };
            Customer? newCustomer = await mediator.Send(command);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            Customer? customer = await mediator.Send(new DeleteCustomerCommand(id));
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
        }
    }
}
