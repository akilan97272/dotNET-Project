using AICalendar.Shared.Models;
using AICalendar.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=aicalendar.db"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "🚀 AI Calendar API running with EF Core!");

// List events
app.MapGet("/events", async (AppDbContext db) =>
    await db.Events.ToListAsync());

// Get event by id
app.MapGet("/events/{id}", async (Guid id, AppDbContext db) =>
    await db.Events.FindAsync(id) is EventDto ev ? Results.Ok(ev) : Results.NotFound());

// Create event
app.MapPost("/events", async (EventDto newEvent, AppDbContext db) =>
{
    newEvent.Id = Guid.NewGuid();
    db.Events.Add(newEvent);
    await db.SaveChangesAsync();
    return Results.Created($"/events/{newEvent.Id}", newEvent);
});

// Update event
app.MapPut("/events/{id}", async (Guid id, EventDto updatedEvent, AppDbContext db) =>
{
    var ev = await db.Events.FindAsync(id);
    if (ev is null) return Results.NotFound();

    ev.Title = updatedEvent.Title;
    ev.Start = updatedEvent.Start;
    ev.End = updatedEvent.End;
    ev.Attendees = updatedEvent.Attendees;

    await db.SaveChangesAsync();
    return Results.Ok(ev);
});

// Delete event
app.MapDelete("/events/{id}", async (Guid id, AppDbContext db) =>
{
    var ev = await db.Events.FindAsync(id);
    if (ev is null) return Results.NotFound();

    db.Events.Remove(ev);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
