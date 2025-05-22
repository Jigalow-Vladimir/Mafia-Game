using Mafia.Models.Resources;

namespace Mafia.Models.Roles;

public sealed class Doctor : Role
{
    public Doctor(string? name = null)
        : base(name)
    {
        this._func = Save;
    }

    private string Save(IRole? role)
    {
        if (role == null)
            return "skip";

        if (role.Status == Status.Killed)
        {
            role.Status = Status.Saved;
        
            return "success";
        }

        return "skip";
    }
}