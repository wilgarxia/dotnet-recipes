using SerilogLogging;
using SerilogLogging.Services;

using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        services.AddSingleton<App>();
        services.AddSingleton<IDummyService, DummyService>();
        services.AddTransient<ILogger>(x => Log.Logger);

        return services;
    }
}
