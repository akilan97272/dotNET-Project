using System;
using Xunit;
using AICalendar.Domain;

namespace AICalendar.Tests
{
    public class EventFactoryTests
    {
        [Fact]
        public void Create_ShouldGenerateEventWithAttendees()
        {
            // Arrange
            var title = "Team Sync";
            var start = DateTime.Now;
            var end = start.AddHours(1);

            // Act
            var ev = EventFactory.Create(title, start, end, "aki@example.com", "sandyaa@example.com");

            // Assert
            Assert.NotNull(ev);
            Assert.Equal(title, ev.Title);
            Assert.Equal(2, ev.Attendees.Count);
            Assert.Contains("aki@example.com", ev.Attendees);
            Assert.Contains("sandyaa@example.com", ev.Attendees);
        }
    }
}
