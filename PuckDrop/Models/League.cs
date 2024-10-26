namespace PuckDrop.Models;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public LeagueType Type { get; set; }
    public Guid Commissioner { get; set; }
    public ICollection<Team> Teams { get; set; } = new List<Team>();
}

public enum LeagueType
{
    Daily = 0,
    Seasonal = 1
}
