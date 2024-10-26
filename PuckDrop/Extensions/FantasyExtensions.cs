using PuckDrop.Services;

namespace PuckDrop.Extensions;

public static class FantasyExtensions
{
    public static IServiceCollection AddFantasyServices(this IServiceCollection services)
    {
        services.AddScoped<ILeagueService, LeagueService>();
        return services;
    }
}
