// using Google.Apis.Auth.OAuth2;
// using Google.Apis.Calendar.v3;
// using Google.Apis.Calendar.v3.Data;
// using Google.Apis.Services;
// using Google.Apis.Util.Store;

// namespace AICalendar.Api;

// public class GoogleCalendarServiceHelper
// {
//     private readonly CalendarService _service;

//     public GoogleCalendarServiceHelper()
//     {
//         string[] scopes = { CalendarService.Scope.Calendar };

//         using var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read);
//         string credPath = "token.json";

//         var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//         GoogleClientSecrets.FromStream(stream).Secrets,
//         scopes,
//         "user",
//         CancellationToken.None,
//         new FileDataStore(credPath, true)
//         ).Result ?? throw new InvalidOperationException("Failed to authorize Google API");



//         _service = new CalendarService(new BaseClientService.Initializer()
//         {
//             HttpClientInitializer = credential,
//             ApplicationName = "AICalendar"
//         });
//     }

//     public Events ListEvents(string calendarId = "primary", int maxResults = 10)
//     {
//         var request = _service.Events.List(calendarId);
//         request.MaxResults = maxResults;
//         request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
//         request.SingleEvents = true;
//         return request.Execute();
//     }

//     public Event CreateEvent(string title, DateTime start, DateTime end, string[] attendeesEmails = null)
//     {
//         var newEvent = new Event
//         {
//             Summary = title,
//             Start = new EventDateTime { DateTimeRaw = start.ToString("yyyy-MM-ddTHH:mm:sszzz") },
//             End = new EventDateTime { DateTimeRaw = end.ToString("yyyy-MM-ddTHH:mm:sszzz") }
//         };

//         if (attendeesEmails != null)
//             newEvent.Attendees = attendeesEmails.Select(e => new EventAttendee { Email = e }).ToList();

//         return _service.Events.Insert(newEvent, "primary").Execute();
//     }

//     public void DeleteEvent(string eventId)
//     {
//         _service.Events.Delete("primary", eventId).Execute();
//     }
// }
