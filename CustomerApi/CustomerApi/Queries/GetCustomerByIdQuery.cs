using CustomerApi.Models;
using CustomerApi.Services.Customers;
using MediatR;

namespace CustomerApi.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>
    {
    }
    public class GetCustomerByIdQueryHandler(ICustomerService customerService) :
        IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await customerService.GetCustomerById(request.Id);
        }
    }
}
