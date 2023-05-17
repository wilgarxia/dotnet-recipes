using DefaultIocContainer.Services;

namespace DefaultIocContainer;

public class App
{
    private readonly IDummyService _service;

    public App(IDummyService service)
    {
        _service = service;
    }

    public async Task Run(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            Console.WriteLine("Doing some work...");

            await _service.DoSomeWork(ct);

            Console.WriteLine("Work completed.\n");

            await Task.Delay(3000);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}