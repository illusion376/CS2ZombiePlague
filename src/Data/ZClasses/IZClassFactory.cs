using CS2ZombiePlague.Data.ZClasses.Abilities;

namespace CS2ZombiePlague.Data.ZClasses;

public interface IZClassFactory
{
    public IZAbility Create<T>() where T : IZAbility;
}