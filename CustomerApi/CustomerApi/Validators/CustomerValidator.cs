using CustomerApi.Models;
using FluentValidation;

namespace CustomerApi.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(Customer=>Customer.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(Customer => Customer.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(Customer => Customer.Phone).NotEmpty().WithMessage("Phone is required");
        }
    }
}
