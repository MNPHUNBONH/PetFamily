using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Volunteers;
using PetFamily.Infrastructure.Repository;

namespace PetFamily.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        return services;
    }
}