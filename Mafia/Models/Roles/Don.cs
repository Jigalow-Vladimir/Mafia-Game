using Mafia.Models.Resources;

namespace Mafia.Models.Roles;

public sealed class Don : Mafiosi
{
    public Don(string? name = null)
        : base(name)
    {
        this._func = Kill;
    }

    private string Kill(IRole? role)
    {
        if (role == null)
            return "skip";

        role.Status = Status.Killed;

        return "target is chosen";
    }
}