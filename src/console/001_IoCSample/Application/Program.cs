using Microsoft.Extensions.DependencyInjection;
using Application;

var services = new ServiceCollection();

services.AddServices();
services.AddSingleton<string[]>(args);

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();

using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, eventArgs) =>
{
    cts.Cancel();
    eventArgs.Cancel = true;

    Console.WriteLine("\nCanceling...");
};

await app.Run(cts.Token);