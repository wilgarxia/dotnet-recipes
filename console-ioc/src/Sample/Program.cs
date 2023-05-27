using Microsoft.Extensions.DependencyInjection;
using Sample;

var services = new ServiceCollection();

services.AddServices();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApplication>();

using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, eventArgs) =>
{
    cts.Cancel();
    eventArgs.Cancel = true;

    Console.WriteLine("\nCanceling...");
};

try
{
    await app.Run(cts.Token);
}
catch (Exception ex)
{
    if (ex is not TaskCanceledException)
        Console.WriteLine(ex.Message);
}