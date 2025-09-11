using System;
using System.Collections.Generic;

namespace AICalendar.Shared.Models
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Attendees { get; set; } = new();
    }
}
