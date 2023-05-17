using Microsoft.Extensions.DependencyInjection;
using DefaultIocContainer;
using DefaultIocContainer.Services;

var services = new ServiceCollection();

services.AddSingleton<App>();
services.AddSingleton<IDummyService, DummyService>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();

using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, eventArgs) =>
{
    cts.Cancel();
    eventArgs.Cancel = true;

    Console.WriteLine("Canceling...");
};

await app.Run(cts.Token);