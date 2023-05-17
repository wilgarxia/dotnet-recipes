using Application.Services;

namespace Application;

public class App
{
    private readonly IGreeterService _greeterService;

    public App(IGreeterService greeterService)
    {
        _greeterService = greeterService;
    }

    public async Task Run(CancellationToken ct)
    {
        Console.WriteLine(_greeterService.SayGreeting());

        await Task.CompletedTask;
    }
}