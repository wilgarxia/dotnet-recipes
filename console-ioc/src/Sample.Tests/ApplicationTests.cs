using Sample.Services;
using Sample.Helpers;

namespace Sample.Tests;

public class ApplicationTests
{
    private readonly IConsoleWriter _consoleWriter = Substitute.For<IConsoleWriter>();
    private readonly IDummyService _dummyService = Substitute.For<IDummyService>();
    private readonly IApplication _sut;
    private readonly CancellationTokenSource _cts = new();

    public ApplicationTests() => 
        _sut = new Application(_consoleWriter, _dummyService);

    [Fact]
    public async Task Run_ShouldWriteToConsole_WhenCalled()
    {
        // Arrange
        _dummyService.DoSomeWork(Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);

        // Act
        await _sut.Run(_cts.Token);

        // Assert
        _consoleWriter.Received(2).WriteLine(Arg.Any<string>());
    }
}