using Application;

public interface IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow { get; }
}

public class DateTimeOffsetProvider : IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}