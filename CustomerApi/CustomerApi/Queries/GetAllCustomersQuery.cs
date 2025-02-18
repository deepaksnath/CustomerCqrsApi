using CustomerApi.Models;
using CustomerApi.Services.Customers;
using MediatR;

namespace CustomerApi.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {

    }
    public class GetAllCustomersQueryHandler(ICustomerService customerService) :
        IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerService.GetCustomers();
        }
    }
}
