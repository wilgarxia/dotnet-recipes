using Sample.Services;

namespace Application.Tests.Services;

public class DummyServiceTests
{
    private readonly IDummyService _sut = new DummyService();
    private readonly CancellationTokenSource _cts = new();

    [Fact]
    public async Task DoSomeWork_ShouldThrowAnException_WhenCancellationTokenIsCancelled()
    {
        // Arrange
        
        // Act
        _cts.Cancel();
        Func<Task> result = async () => await _sut.DoSomeWork(_cts.Token);

        // Assert
        await result.Should().ThrowAsync<TaskCanceledException>();
    }

    [Fact]
    public async Task DoSomeWork_ShouldNotThrowAnException_WhenCancellationTokenIsNotCancelled()
    {
        // Arrange

        // Act
        Func<Task> result = async () => await _sut.DoSomeWork(_cts.Token);        

        // Assert
        await result.Should().CompleteWithinAsync(TimeSpan.FromSeconds(5));
    }
}