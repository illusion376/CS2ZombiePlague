using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Players;

namespace CS2ZombiePlague.Data.ZClasses.Abilities;

public class ZAbilityFactory(ISwiftlyCore core, Utils utils) : IZAbilityFactory
{
    public IZAbility Create<T>() where T : IZAbility
    {
        return typeof(T) switch
        {
            var t when t == typeof(Heal) => new Heal(core, utils),
            _ => throw new NotSupportedException("ZAbilityFactory: type T hasn't supported!")
        };
    }
}