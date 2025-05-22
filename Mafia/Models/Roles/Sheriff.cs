using Mafia.Models.Resources;

namespace Mafia.Models.Roles;

public sealed class Sheriff : Role
{
    public Sheriff(string? name = null)
        : base(name)
    {
        this.Team = Team.City;

        this._func = Check;
    }

    private string Check(IRole? role)
    {
        if (role == null)
            return "skip";

        bool isMafia = role.Team == Team.Mafia;

        string message = $"is mafia: {isMafia}";

        return message;
    }
}