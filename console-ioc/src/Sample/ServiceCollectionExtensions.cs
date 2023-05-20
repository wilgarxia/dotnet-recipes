using Sample;
using Sample.Helpers;
using Sample.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<IDummyService, DummyService>();
        services.AddSingleton<IApplication, Application>();

        return services;
    }
}
