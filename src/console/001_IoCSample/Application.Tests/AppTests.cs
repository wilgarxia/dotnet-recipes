using Application.Services;
using Application.Helpers;

namespace Application.Tests;

public class AppTests
{
    private readonly Mock<IGreeterService> _greeterService;
    private readonly Mock<IConsoleWriter> _consoleWriter;

    public AppTests()
    {
        _greeterService = new Mock<IGreeterService>();
        _consoleWriter = new Mock<IConsoleWriter>();
    }

    [Fact]
    public async Task Run_ShouldNotGreet_WhenCancellationTokenIsRequested()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        App app = new(_greeterService.Object, _consoleWriter.Object);
        string[] args = Array.Empty<string>();

        // Act
        cts.Cancel();
        await app.Run(args, cts.Token);

        // Assert
        _consoleWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
    } 

    [Fact]
    public async Task Run_ShouldGreet_WhenParameterIsEmpty()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        App app = new(_greeterService.Object, _consoleWriter.Object);
        string[] args = Array.Empty<string>();

        // Act
        await app.Run(args, cts.Token);

        // Assert
        _consoleWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
    }     

    [Fact]
    public async Task Run_ShouldGreet_WhenParameterContainsAtLeastOneValue()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        App app = new(_greeterService.Object, _consoleWriter.Object);
        string[] args = new string[] { "foo" };

        // Act
        await app.Run(args, cts.Token);

        // Assert
        _consoleWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
    }    
}