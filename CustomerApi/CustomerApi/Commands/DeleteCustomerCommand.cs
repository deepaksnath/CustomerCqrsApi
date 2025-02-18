using CustomerApi.Models;
using CustomerApi.Services.Customers;
using MediatR;

namespace CustomerApi.Commands
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<Customer>
    {
    }

    public class DeleteCustomerCommandHandler(ICustomerService customerService) :
        IRequestHandler<DeleteCustomerCommand, Customer?>
    {
        public async Task<Customer?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerService.DeleteCustomer(request.Id);
        }
    }
}
