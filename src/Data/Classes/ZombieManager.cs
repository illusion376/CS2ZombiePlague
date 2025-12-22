using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS2ZombiePlague.src.Data.Classes
{
    public class ZombieManager(ISwiftlyCore _core)
    {
        private Dictionary<int, ZombiePlayer> ZombiePlayers = new()!;

        public ZombiePlayer CreateZombie(IPlayer player)
        {
            return ZombiePlayers[player.PlayerID] = new ZombiePlayer(new ZombieHeavy(), player);
        }

        public void Remove(IPlayer player)
        {
            ZombiePlayers.Remove(player.PlayerID);
        }

        public void RemoveAll()
        {
            ZombiePlayers.Clear();
        }

        public bool IsInfected(IPlayer player)
        {
            return ZombiePlayers.ContainsKey(player.PlayerID);
        }
    }
}
