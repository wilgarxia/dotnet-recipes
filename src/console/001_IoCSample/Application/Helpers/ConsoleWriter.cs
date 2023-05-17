namespace Application.Helpers;

public interface IConsoleWriter
{
    void WriteLine(string text);
}

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
}