namespace AICalendar.Shared.Models;

public record EventDto
{

    public Guid Id { get; init; } = Guid.NewGuid(); // add this
    public string Title { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public string[]? Attendees { get; init; }
}
