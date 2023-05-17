using SerilogLogging.Services;
using Serilog;

namespace SerilogLogging;

public class App
{
    private readonly IDummyService _service;
    private readonly ILogger _logger;

    public App(IDummyService service, ILogger logger)
    {
        _service = service;
        _logger = logger;
    }

    public async Task Run(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            _logger.Information("Doing some work...");

            await _service.DoSomeWork(ct);

            _logger.Information("Work completed.");

            await Task.Delay(3000);
        }
    }
}