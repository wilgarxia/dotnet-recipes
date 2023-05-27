using Sample.Helpers;
using Sample.Services;

namespace Sample;

internal class Application : IApplication
{
    private readonly IConsoleWriter _consoleWriter;
    private readonly IDummyService _dummyService;

    public Application(
        IConsoleWriter consoleWriter, 
        IDummyService dummyService)
    {
        _consoleWriter = consoleWriter;
        _dummyService = dummyService;
    }

    public async Task Run(CancellationToken ct)
    {
        _consoleWriter.WriteLine("Welcome to the IoC sample.");

        await _dummyService.DoSomeWork(ct);

        _consoleWriter.WriteLine("IoC sample is complete.");
    }
}