using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Infrastructure.Data;
using PizzaX.Infrastructure.Repositories;

namespace PizzaX.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        /* Db Context - Connection */
        services.AddDbContext<PizzaXDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        /* Repositories */
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //services.AddScoped<IPizzaVarietyRepository, PizzaVarietyRepository>();
        //services.AddScoped<IDealItemRepository, DealItemRepository>();
        //services.AddScoped<IDealRepository, DealRepository>();

        return services;
    }
}
