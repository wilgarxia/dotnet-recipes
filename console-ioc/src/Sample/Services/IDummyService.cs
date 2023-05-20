namespace Sample.Services;

public interface IDummyService
{
    Task DoSomeWork(CancellationToken ct);
}