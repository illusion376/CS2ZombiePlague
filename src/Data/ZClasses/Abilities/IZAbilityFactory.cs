using SwiftlyS2.Shared.Players;

namespace CS2ZombiePlague.Data.ZClasses.Abilities;

public interface IZAbilityFactory
{
    public IZAbility Create<T>() where T : IZAbility;
}