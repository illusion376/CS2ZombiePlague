namespace CS2ZombiePlague.Data.Abilities.Contracts;

public interface IAbilityFactory
{
    public IAbility Create<T>() where T : IAbility;
}