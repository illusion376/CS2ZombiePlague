using SwiftlyS2.Shared.SchemaDefinitions;

namespace CS2ZombiePlague.Data.Abilities.Contracts;

public interface IParticleRestricted
{
    public CParticleSystem? Particle { get; set; }

    public void DestroyParticle();

    void CreateParticle();
}