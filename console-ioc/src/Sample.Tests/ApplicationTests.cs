using Sample.Services;
using Sample.Helpers;

namespace Sample.Tests;

public class ApplicationTests
{
    private readonly IConsoleWriter _consoleWriter = Substitute.For<IConsoleWriter>();
    private readonly IGreeterService _greeterService = Substitute.For<IGreeterService>();
    private readonly Application _application;

    public ApplicationTests()
    {
        _application = new(_greeterService, _consoleWriter);
    }

    [Fact]
    public async Task Run_ShouldNotGreet_WhenCancellationTokenIsRequested()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        string[] args = Array.Empty<string>();

        // Act
        cts.Cancel();
        await _application.Run(args, cts.Token);

        // Assert
        _consoleWriter.Received(1).WriteLine(Arg.Any<string>());
    } 

    [Fact]
    public async Task Run_ShouldGreet_WhenParameterIsEmpty()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        string[] args = Array.Empty<string>();

        _greeterService.SayGreeting().Returns("Good morning");

        // Act
        await _application.Run(args, cts.Token);

        // Assert
        _consoleWriter.Received(2).WriteLine(Arg.Any<string>());
        _consoleWriter.Received(1).WriteLine(Arg.Is("Good morning!"));
    }     

    [Fact]
    public async Task Run_ShouldGreet_WhenParameterContainsAtLeastOneValue()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        string[] args = new string[] { "Foo" };

        _greeterService.SayGreeting().Returns("Good morning");

        // Act
        await _application.Run(args, cts.Token);

        // Assert
        _consoleWriter.Received(2).WriteLine(Arg.Any<string>());
        _consoleWriter.Received(1).WriteLine(Arg.Is("Good morning Foo!"));
    }    
}