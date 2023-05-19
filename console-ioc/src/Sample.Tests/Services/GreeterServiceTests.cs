using Sample.Services;
using Sample.Helpers;

namespace Application.Tests.Services;

public class GreeterServiceTests
{
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider = Substitute.For<IDateTimeOffsetProvider>();
    private readonly IGreeterService _greeterService;
    private readonly DateOnly _frozenDate = DateOnly.FromDateTime(DateTimeOffset.UtcNow.Date);

    public GreeterServiceTests()
    {
        _greeterService = new GreeterService(_dateTimeOffsetProvider);
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodMorning_WhenIsMorning()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{_frozenDate} 08:00:00");

        _dateTimeOffsetProvider.UtcNow.Returns(date);

        // Act
        var greeting = _greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good morning");
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodEvening_WhenIsEvening()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{_frozenDate} 14:00:00");
        
        _dateTimeOffsetProvider.UtcNow.Returns(date);

        // Act
        var greeting = _greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good evening");
    }

    [Fact]
    public void SayGreeting_ShouldReturnGoodNight_WhenIsNight()
    {
        // Arrange
        var date = DateTimeOffset.Parse($"{_frozenDate} 20:00:00");
        
        _dateTimeOffsetProvider.UtcNow.Returns(date);

        // Act
        var greeting = _greeterService.SayGreeting();

        // Assert
        greeting.Should().Be("Good night");
    }    
}