using Microsoft.EntityFrameworkCore;
using PuckDrop.Models;

namespace PuckDrop.Data;

public class FantasyDbContext : DbContext
{
    public FantasyDbContext(DbContextOptions<FantasyDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<League> Leagues { get; set; }
    public DbSet<Team> Teams { get; set; }
}
