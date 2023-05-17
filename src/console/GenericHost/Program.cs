using GenericHost;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting host");

    var builder = Host.CreateDefaultBuilder(args); 

    // graceful shutdown
    builder.UseConsoleLifetime(); 
    
    builder.ConfigureServices(services =>
        {
            services.AddHostedService<Worker>();
        })
        .UseSerilog();

    var host = builder.Build();

    host.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}