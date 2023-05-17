namespace SerilogLogging.Services;

public interface IDummyService
{
    Task DoSomeWork(CancellationToken ct);
}

public class DummyService : IDummyService
{
    public async Task DoSomeWork(CancellationToken ct)
    {
        if (ct.IsCancellationRequested)
            return;

        await Task.Delay(500);
    }
}