using Mafia.Models;
using Mafia.Models.Resources;
using Mafia.Models.Roles;

namespace Mafia;

public class Startup
{
    private readonly PlayersStorage _playersStorage;

    public Startup()
    {
        _playersStorage = new();
    }

    public string MafiaStep(IRole? target)
    {
        var don = _playersStorage.Roles
            .First(i => i is Don &&
                i.Status == Status.Alive);

        if (don == null)
        {
            var key = _playersStorage.Players
                .First(i => i.Value is Mafiosi &&
                    i.Value.Status == Status.Alive).Key;

            if (key != null)
            {
                don = new Don();
                _playersStorage.Players[key] = don;
            }
            else return string.Empty;
        }

        return don.Act(target);
    }

    public List<string> DoctorStep(List<IRole> targets)
    {
        List<string> results = [];

        var doctors = _playersStorage.Roles
            .Where(i => i is Doctor)
            .ToList();

        if (doctors != null && doctors.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                results.Add(doctors[i].Act(targets[i]));
            }
        }

        return results;
    }

    public List<string> SheriffStep(List<IRole> targets)
    {
        List<string> results = [];

        var sheriffs = _playersStorage.Roles
            .Where(i => i is Sheriff)
            .ToList();

        if (sheriffs != null && sheriffs.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                results.Add(sheriffs[i].Act(sheriffs[i]));
            }
        }

        return results;
    }
}