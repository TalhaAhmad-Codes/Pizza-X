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
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPizzaVarietyService, PizzaVarietyService>();

            return services;
        }
    }
}
