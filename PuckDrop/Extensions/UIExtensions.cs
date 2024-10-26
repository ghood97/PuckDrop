using PuckDrop.Services;

namespace PuckDrop.Extensions;

public static class UIExtensions
{
    public static IServiceCollection AddSharedUIServices(this IServiceCollection services)
    {
        services.AddScoped<ISnackbarService, SnackbarService>();
        return services;
    }
}
