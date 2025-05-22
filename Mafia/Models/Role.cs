using Mafia.Models.Resources;

namespace Mafia.Models;

public abstract class Role : IRole
{
    protected Func<IRole?, string>? _func;

    public string Name { get; set; } = string.Empty;

    public Team Team { get; set; } = Team.City;

    public Status Status { get; set; } = Status.Alive;

    public Role(string? name = null)
    {
        this.Name = name ?? this.GetType().Name;
    }

    public string Act(IRole? role)
    {
        var message = this._func?.Invoke(role) ?? "skip";

        return message;
    }
}