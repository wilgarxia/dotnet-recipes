using Microsoft.Extensions.DependencyInjection;
using SerilogLogging;
using SerilogLogging.Services;
using Serilog;

var services = new ServiceCollection();

services.AddServices();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();

using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, eventArgs) =>
{
    cts.Cancel();
    eventArgs.Cancel = true;

    Log.CloseAndFlush();

    Console.Clear();
    Console.WriteLine("Canceling...");
};

await app.Run(cts.Token);