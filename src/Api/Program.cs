using AICalendar.Api;
using AICalendar.Shared.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var calendarService = new GoogleCalendarServiceHelper();

// In-memory events (optional, for your API layer)
var events = new List<EventDto>();

// Get events from Google Calendar
app.MapGet("/events", () =>
{
    var gEvents = calendarService.ListEvents();
    return Results.Ok(gEvents.Items);
});

// Create event in Google Calendar
app.MapPost("/events", (EventDto newEvent) =>
{
    var ev = calendarService.CreateEvent(newEvent.Title, newEvent.Start, newEvent.End, newEvent.Attendees);
    return Results.Created($"/events/{ev.Id}", ev);
});

// Delete event by ID
app.MapDelete("/events/{id}", (string id) =>
{
    calendarService.DeleteEvent(id);
    return Results.Ok();
});

app.Run();
