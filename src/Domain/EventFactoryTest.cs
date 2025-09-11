using System;

namespace AICalendar.Domain
{
    public class EventFactoryTest
    {
        public static void RunTest()
        {
            var ev = EventFactory.Create(
                "Team Sync",
                DateTime.Now,
                DateTime.Now.AddHours(1),
                "aki@example.com",
                "sandyaa@example.com"
            );

            Console.WriteLine($"📅 Event: {ev.Title}, from {ev.Start} to {ev.End}");
            Console.WriteLine($"👥 Attendees: {string.Join(", ", ev.Attendees)}");
        }
    }
}
