using CustomerApi.Models;
using CustomerApi.Data.Customers;
using MediatR;

namespace CustomerApi.Commands
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<Customer>
    {
    }

    public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) :
        IRequestHandler<DeleteCustomerCommand, Customer?>
    {
        public async Task<Customer?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.DeleteCustomer(request.Id);
        }
    }
}
