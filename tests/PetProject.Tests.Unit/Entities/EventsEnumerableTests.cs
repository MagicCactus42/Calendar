using FluentAssertions;
using PetProject.Core.Entities;
using PetProject.Core.Exceptions;
using PetProject.Core.ValueObjects;

namespace Entities;

public class EventsEnumerableTests
{
    [Theory]
    [InlineData("2023-07-11")]
    [InlineData("2024-02-19")]
    public void given_invalid_date_interval_AddEvents_should_fail(string dateString)
    {
        var invalidDate = DateTimeOffset.Parse(dateString);

        var events = new Events(Guid.NewGuid(), "Test Event",
            "Lorem ipsum", true, invalidDate, invalidDate.AddDays(1),
            Guid.NewGuid(), true);

        var exception = Record.Exception(() => _eventsEnumerable.AddEvent(events, _datetime));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<InvalidEventTimeInterval>();
    }

    [Fact]
    public void overlapping_event_that_cannot_be_overlapped_should_fail()
    {
        var date = DateTimeOffset.UtcNow.AddHours(5);
        
        var event1 = new Events(Guid.NewGuid(), "Test Event1",
            "Lorem ipsum", true, date, date.AddDays(1),
            Guid.NewGuid(), false);
        
        var event2 = new Events(Guid.NewGuid(), "Test Event2",
            "Lorem ipsum", true, date.AddHours(1), date.AddDays(1),
            Guid.NewGuid(), true);
        
        _eventsEnumerable.AddEvent(event1, _datetime);
        var exception = Record.Exception(() => _eventsEnumerable.AddEvent(event2, _datetime));
        
        exception.Should().NotBeNull();
        exception.Should().BeOfType<EventTimeIntervalOverlapException>();
    }
    
    #region ARRANGE
    
    private readonly EventsEnumerable _eventsEnumerable;
    private readonly Date _datetime;

    public EventsEnumerableTests()
    {
        _eventsEnumerable = new EventsEnumerable();
        _datetime = new Date(new DateTime(2025, 2, 20));
    }
    
    #endregion
}