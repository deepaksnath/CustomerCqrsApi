using CustomerApi.Models;
using CustomerApi.Data.Customers;
using MediatR;

namespace CustomerApi.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; }
    }


    public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) :
        IRequestHandler<UpdateCustomerCommand, Customer?>
    {
        public async Task<Customer?> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = new()
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                HasLoyaltyMembership = command.HasLoyaltyMembership,
                Phone = command.Phone
            };
            return await customerRepository.UpdateCustomer(customer);
        }
    }
}
