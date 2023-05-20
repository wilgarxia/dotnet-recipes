using Sample.Services;

namespace Application.Tests.Services;

public class DummyServiceTests
{
    private readonly IDummyService _dummyService = new DummyService();

    [Fact]
    public async Task DoSomeWork_ShouldThrowAnException_WhenCancellationTokenIsCancelled()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        // Act
        cts.Cancel();
        Func<Task> result = async () => await _dummyService.DoSomeWork(cts.Token);

        // Assert
        await result.Should().ThrowAsync<TaskCanceledException>();
    }

    [Fact]
    public async Task DoSomeWork_ShouldNotThrowAnException_WhenCancellationTokenIsNotCancelled()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        // Act
        Func<Task> result = async () => await _dummyService.DoSomeWork(cts.Token);

        // Assert
        await result.Should().CompleteWithinAsync(TimeSpan.FromSeconds(5));
    }
}