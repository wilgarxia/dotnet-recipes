namespace Sample.Helpers;

internal class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
}