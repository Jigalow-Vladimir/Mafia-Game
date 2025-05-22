using Mafia.Models.Resources;

namespace Mafia.Models;

public interface IRole
{
    public string Name { get; set; }

    public Team Team { get; set; }

    public Status Status { get; set; }

    public string Act(IRole? role);
}