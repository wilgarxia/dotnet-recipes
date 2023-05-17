using DefaultIocContainer;
using DefaultIocContainer.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<App>();
        services.AddSingleton<IDummyService, DummyService>();

        return services;
    }
}
