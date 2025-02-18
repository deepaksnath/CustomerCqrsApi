using CustomerApi.Models;
using CustomerApi.Data.Customers;
using MediatR;

namespace CustomerApi.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>
    {
    }
    public class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository) :
        IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetCustomerById(request.Id);
        }
    }
}
