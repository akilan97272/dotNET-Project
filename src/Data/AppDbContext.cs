using Microsoft.EntityFrameworkCore;
using AICalendar.Shared.Models;

namespace AICalendar.Data;

public class AppDbContext : DbContext
{
    public DbSet<EventDto> Events => Set<EventDto>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
