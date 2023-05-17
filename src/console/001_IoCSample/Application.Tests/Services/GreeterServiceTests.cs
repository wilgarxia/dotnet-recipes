using Application.Services;
using Application.Helpers;

namespace Application.Tests.Services;

public class GreeterServiceTests
{
    private readonly Mock<IDateTimeOffsetProvider> _dateTimeOffsetProvider;

    public GreeterServiceTests()
    {
        _dateTimeOffsetProvider = new Mock<IDateTimeOffsetProvider>();
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodMorning_WhenIsMorning()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{DateOnly.FromDateTime(DateTimeOffset.UtcNow.Date)} 08:00:00");
        GreeterService greeterService = new(_dateTimeOffsetProvider.Object);
        _dateTimeOffsetProvider.SetupGet(x => x.UtcNow).Returns(date);

        // Act
        var greeting = greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good morning");
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodEvening_WhenIsEvening()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{DateOnly.FromDateTime(DateTimeOffset.UtcNow.Date)} 14:00:00");
        GreeterService greeterService = new(_dateTimeOffsetProvider.Object);
        _dateTimeOffsetProvider.SetupGet(x => x.UtcNow).Returns(date);

        // Act
        var greeting = greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good evening");
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodNight_WhenIsNight()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{DateOnly.FromDateTime(DateTimeOffset.UtcNow.Date)} 20:00:00");
        GreeterService greeterService = new(_dateTimeOffsetProvider.Object);
        _dateTimeOffsetProvider.SetupGet(x => x.UtcNow).Returns(date);

        // Act
        var greeting = greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good night");
    }    
}