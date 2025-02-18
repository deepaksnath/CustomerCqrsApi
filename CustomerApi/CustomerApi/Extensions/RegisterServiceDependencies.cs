using CustomerApi.Repositories;
using CustomerApi.Repositories.Customers;
using CustomerApi.Services.Customers;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerApi.Extensions
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //MediatR
            builder.Services.AddMediatR(s => s.RegisterServicesFromAssemblyContaining<Program>());

            //Fluent Validations
            //builder.Services.AddControllers().AddFluentValidation(
            //    v=>v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            //Global Exception Handling
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //DB Context
            var CONNECTION_STRING = builder.Configuration.GetConnectionString("CustomerDbConnection");
            builder.Services.AddDbContextPool<CustomerDbContext>(
                options => options.UseSqlServer(CONNECTION_STRING));
                        
            //Services
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            return builder;
        }
    }
}
