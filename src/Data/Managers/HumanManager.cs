using CS2ZombiePlague.Data.Extensions;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Natives;
using SwiftlyS2.Shared.Players;

namespace CS2ZombiePlague.Data.Managers;

public class HumanManager(ISwiftlyCore core)
{
    public int GetCountHumans()
    {
        var humans = GetAllHumans();
        return humans.Count;
    }
    
    private List<IPlayer> GetAllHumans()
    {
        List<IPlayer> humans = [];

        var allPlayers = core.PlayerManager.GetAllPlayers();
        foreach (var player in allPlayers)
        {
            if (player != null && !player.IsInfected() && player.Controller.PawnIsAlive)
            {
                humans.Add(player);
            }
        }

        return humans;
    }
}