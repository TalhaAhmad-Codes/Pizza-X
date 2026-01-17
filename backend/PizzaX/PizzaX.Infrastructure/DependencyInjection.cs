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
        /* Db Context */
        services.AddDbContext<PizzaXDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        /* Repositories */
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPizzaRepository, PizzaRepository>();
        services.AddScoped<IPizzaVarietyRepository, PizzaVarietyRepository>();
        services.AddScoped<IFriesRepository, FriesRepository>();
        services.AddScoped<IDrinkRepository, DrinkRepository>();

        return services;
    }
}
