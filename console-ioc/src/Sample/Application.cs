using System.Text;
using Sample.Services;
using Sample.Helpers;

namespace Sample;

public class Application
{
    private readonly IGreeterService _greeterService;
    private readonly IConsoleWriter _consoleWriter;

    public Application(IGreeterService greeterService, IConsoleWriter consoleWriter)
    {
        _greeterService = greeterService;
        _consoleWriter = consoleWriter;
    }

    public async Task Run(string[] parameters, CancellationToken ct)
    {
        _consoleWriter.WriteLine(
            "Welcome to the Greeting Service. \nPlease wait a few seconds while your Greeting is being generated...\n");

        // This Delay makes cancelling possible by pressing Ctrl + C.
        // It's here just to demonstrate console cancelling using Cancellation Tokens and CancelKeyPress Event.
        try
        {
            await Task.Delay(3000, ct);
        }
        catch (TaskCanceledException) 
        {
            return;
        }

        StringBuilder builder = new(_greeterService.SayGreeting());

        builder.Append(parameters.Length > 0 ? $" {parameters[0]}!" : "!");

        _consoleWriter.WriteLine(builder.ToString());

        await Task.CompletedTask;
    }
}