using Microsoft.EntityFrameworkCore;
using PuckDrop.Data;
using PuckDrop.Models;

namespace PuckDrop.Services;

public interface ILeagueService
{
    public Task<List<League>> GetLeagues();
}

public class LeagueService : ILeagueService
{
    private readonly IDbContextFactory<FantasyDbContext> _contextFactory;

    public LeagueService(IDbContextFactory<FantasyDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<League>> GetLeagues()
    {
        using FantasyDbContext context = _contextFactory.CreateDbContext();
        return await context.Leagues.ToListAsync();
    }
}
