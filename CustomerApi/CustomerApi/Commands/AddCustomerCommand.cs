using CustomerApi.Models;
using CustomerApi.Services.Customers;
using MediatR;

namespace CustomerApi.Commands
{
    public class AddCustomerCommand :IRequest<Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Customer Name";
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; } = false;

    }

    public class AddCustomerCommandHandler(ICustomerService customerService) : 
        IRequestHandler<AddCustomerCommand, Customer>
    {
        public async Task<Customer> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = new()
            {
                Name = command.Name,
                Email = command.Email,
                HasLoyaltyMembership = command.HasLoyaltyMembership,
                Phone = command.Phone
            };
            return await customerService.CreateCustomer(customer);
        }
    }
}
