using System.Text;

namespace Application.Services;

public interface IGreeterService
{
    string SayGreeting();
}

public class GreeterService : IGreeterService
{
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly string[] _parameters;

    public GreeterService(IDateTimeOffsetProvider dateTimeOffsetProvider, string[] parameters)
    {
        _parameters = parameters;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public string SayGreeting()
    {
        StringBuilder builder = new(_dateTimeOffsetProvider.UtcNow.Hour switch {
            < 12 => "Good morning",
            < 18 => "Good evening",
            _ => "Good night"
        });

        builder.Append(_parameters.Length > 0 ? $" {_parameters[0]}!" : "!");

        return builder.ToString();
    }
}