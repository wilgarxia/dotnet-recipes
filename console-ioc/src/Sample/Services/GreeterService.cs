using Sample.Helpers;

namespace Sample.Services;

public interface IGreeterService
{
    string SayGreeting();
}

public class GreeterService : IGreeterService
{
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public GreeterService(IDateTimeOffsetProvider dateTimeOffsetProvider)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public string SayGreeting() => 
        _dateTimeOffsetProvider.UtcNow.Hour switch {
            < 12 => "Good morning",
            < 18 => "Good evening",
            _ => "Good night"
        };
}