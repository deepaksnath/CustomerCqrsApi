using CustomerApi.Models;
using CustomerApi.Data.Customers;
using MediatR;

namespace CustomerApi.Commands
{
    public class AddCustomerCommand : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; } = false;

    }

    public class AddCustomerCommandHandler(ICustomerRepository customerRepository) : 
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
            return await customerRepository.CreateCustomer(customer);
        }
    }
}
