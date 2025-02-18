using CustomerApi.Models;
using CustomerApi.Data.Customers;
using MediatR;

namespace CustomerApi.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {

    }
    public class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) :
        IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetCustomers();
        }
    }
}
