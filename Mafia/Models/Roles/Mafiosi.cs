using Mafia.Models.Resources;

namespace Mafia.Models.Roles;

public class Mafiosi : Role
{
    public Mafiosi(string? name = null)
        : base(name)
    {
        this.Team = Team.Mafia;
    }
}