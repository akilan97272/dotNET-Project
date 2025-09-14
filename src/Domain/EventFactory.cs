using System;
using AICalendar.Shared.Models;

namespace AICalendar.Domain
{
    public static class EventFactory
    {
        public static EventDto Create(string title, DateTime start, DateTime end, params string[] attendees)
        {
            return new EventDto
            {
                Id = Guid.NewGuid(),      // Make sure EventDto has Id property
                Title = title,
                Start = start,
                End = end,
                Attendees = attendees     // directly use the params array
            };
        }
    }
}
