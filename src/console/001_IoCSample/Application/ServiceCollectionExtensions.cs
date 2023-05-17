using Application;
using Application.Helpers;
using Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>();
        services.AddSingleton<IGreeterService, GreeterService>();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<App>();

        return services;
    }
}
