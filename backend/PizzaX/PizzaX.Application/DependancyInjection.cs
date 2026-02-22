using Microsoft.Extensions.DependencyInjection;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Services;

namespace PizzaX.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            /* Services */
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IPizzaVarietyService, PizzaVarietyService>();
            //services.AddScoped<IDealItemService, DealItemService>();
            //services.AddScoped<IDealService, DealService>();

            return services;
        }
    }
}
