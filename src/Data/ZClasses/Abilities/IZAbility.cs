using SwiftlyS2.Shared.Players;

namespace CS2ZombiePlague.Data.ZClasses.Abilities;

public interface IZAbility
{
    public void SetCaster(IPlayer caster);
    public void UnHookAbility();
    public void Use();
}