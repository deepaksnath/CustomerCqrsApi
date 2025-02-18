using CustomerApi.Repositories;
using CustomerApi.Repositories.Customers;
using CustomerApi.Services.Customers;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Extensions
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //MediatR
            builder.Services.AddMediatR(s => s.RegisterServicesFromAssemblyContaining<Program>());

            //Fluent Validations
            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            //Global Exception Handling
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //DB Context
            var CONNECTION_STRING = builder.Configuration.GetConnectionString("CustomerDbConnection");
            builder.Services.AddDbContextPool<CustomerDbContext>(
                options => options.UseSqlServer(CONNECTION_STRING));

            //Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Services
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            return builder;
        }
    }
}
