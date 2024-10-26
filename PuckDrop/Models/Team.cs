namespace PuckDrop.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid Owner { get; set; }
    public int LeagueId { get; set; }
    public League League { get; set; } = null!;
}
