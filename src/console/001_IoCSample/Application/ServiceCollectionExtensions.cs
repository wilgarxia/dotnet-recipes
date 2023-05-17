using Application;
using Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>();
        services.AddSingleton<IGreeterService, GreeterService>();
        services.AddSingleton<App>();

        return services;
    }

    public static IServiceCollection AddParameters(this IServiceCollection services, string[] parameters)
    {
        services.AddSingleton<string[]>(parameters);

        return services;
    }
}
