using Mafia.Models.Resources;
using Mafia.Models.Roles;

namespace Mafia.Models;

public sealed class PlayersStorage
{
    public Dictionary<string, IRole> Players;

    public List<IRole> Roles => [.. Players.Select(i => i.Value)];

    public PlayersStorage()
    {
        Players = [];
    }

    public void Refresh()
    {
        foreach (var role in Roles)
        {
            if (role.Status != Status.Killed)
                role.Status = Status.Alive;            
        }
    }

    public void SetPlayers(List<(string nickname, RoleIndex index)> deck)
    {
        foreach (var deckElement in deck)
        {
            switch (deckElement.index)
            {
                case RoleIndex.Civilian:
                    Players.Add(deckElement.nickname, new Civilian());
                    break;
                case RoleIndex.Doctor:
                    Players.Add(deckElement.nickname, new Doctor());
                    break;
                case RoleIndex.Sheriff:
                    Players.Add(deckElement.nickname, new Sheriff());
                    break;
                case RoleIndex.Mafiosi:
                    Players.Add(deckElement.nickname, new Mafiosi());
                    break;
                case RoleIndex.Don:
                    Players.Add(deckElement.nickname, new Don());
                    break;
                default:
                    break;
            }
        }
    }
}