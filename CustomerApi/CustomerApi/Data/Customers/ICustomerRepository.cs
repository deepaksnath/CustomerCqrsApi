using CustomerApi.Models;

namespace CustomerApi.Data.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer?> GetCustomerById(Guid customerId);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer?> UpdateCustomer(Customer customer);

        Task<Customer?> DeleteCustomer(Guid customerId);
    }
}
