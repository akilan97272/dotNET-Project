using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace AICalendar.Api;

public class GoogleCalendarServiceHelper
{
    private readonly CalendarService _service;

    public GoogleCalendarServiceHelper()
    {
        string[] scopes = { CalendarService.Scope.Calendar };
        string credPath = "token.json";

        using var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read);

        // Authorize and store token locally
        var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromStream(stream).Secrets,
            scopes,
            "user", // local key for FileDataStore
            CancellationToken.None,
            new FileDataStore(credPath, true)
        ).Result ?? throw new InvalidOperationException("Failed to authorize Google API");

        _service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "AI Calendar"
        });
    }

    // List upcoming events
    public Events ListEvents(string calendarId = "primary", int maxResults = 10)
    {
        var request = _service.Events.List(calendarId);
        request.MaxResults = maxResults;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.SingleEvents = true;
        return request.Execute();
    }

    // Create a new event
    public Event CreateEvent(string title, DateTime start, DateTime end, string[]? attendeesEmails = null)
{
#pragma warning disable CS0618
    var newEvent = new Event
    {
        Summary = title,
        Start = new EventDateTime { DateTime = start, TimeZone = TimeZoneInfo.Local.Id },
        End = new EventDateTime { DateTime = end, TimeZone = TimeZoneInfo.Local.Id },
        Attendees = attendeesEmails?.Select(e => new EventAttendee { Email = e }).ToList()
    };
#pragma warning restore CS0618

    return _service.Events.Insert(newEvent, "primary").Execute();
}

    // Delete event by ID
    public void DeleteEvent(string eventId)
    {
        _service.Events.Delete("primary", eventId).Execute();
    }
}
