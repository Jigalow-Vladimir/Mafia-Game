using Mafia.Models.Resources;

namespace Mafia.Models.Roles;

public sealed class Civilian : Role
{
    public Civilian(string? name = null)
        : base(name)
    {
        this._func = null;

        this.Team = Team.City;
    }
}