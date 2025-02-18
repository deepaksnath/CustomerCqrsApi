using CustomerApi.Models;
using CustomerApi.Services.Customers;
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


    public class UpdateCustomerCommandHandler(ICustomerService customerService) :
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
            return await customerService.UpdateCustomer(customer);
        }
    }
}
