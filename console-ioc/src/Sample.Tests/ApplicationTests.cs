using Sample.Services;
using Sample.Helpers;

namespace Sample.Tests;

public class ApplicationTests
{
    private readonly IConsoleWriter _consoleWriter = Substitute.For<IConsoleWriter>();
    private readonly IDummyService _dummyService = Substitute.For<IDummyService>();
    private readonly IApplication _application;

    public ApplicationTests()
    {
        _application = new Application(_consoleWriter, _dummyService);
    }

    [Fact]
    public async Task Run_ShouldWriteToConsole_WhenCalled()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        // Act
        _dummyService.DoSomeWork(Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);
        
        await _application.Run(cts.Token);

        // Assert
        _consoleWriter.Received(2).WriteLine(Arg.Any<string>());
    }
}