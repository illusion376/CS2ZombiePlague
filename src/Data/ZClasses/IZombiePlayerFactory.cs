using CS2ZombiePlague.Data.Managers;
using SwiftlyS2.Shared.Players;

namespace CS2ZombiePlague.Data.ZClasses;

public interface IZombiePlayerFactory
{
    public ZombiePlayer Create(IPlayer player, ZombieManager zombieManager, IZombieClass zombieClass, bool isNemesis = false);
}