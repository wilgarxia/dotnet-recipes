namespace Sample.Services;

public interface IDummyService
{
    Task DoSomeWork(CancellationToken ct);
}

public class DummyService : IDummyService
{
    public async Task DoSomeWork(CancellationToken ct)
    {
        await Task.Delay(3000, ct);
    }
}