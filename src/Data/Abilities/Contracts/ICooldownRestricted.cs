namespace CS2ZombiePlague.Data.Abilities.Contracts;

public interface ICooldownRestricted
{
    public bool IsActive { get; set; }
    
    float Cooldown { get; }

    void StartCooldown();

    bool ShouldResetCooldown();

    void ResetCooldown();
}