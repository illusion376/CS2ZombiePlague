using CS2ZombiePlague.Data.Extensions;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Events;
using SwiftlyS2.Shared.Natives;
using SwiftlyS2.Shared.Players;
using SwiftlyS2.Shared.SchemaDefinitions;

namespace CS2ZombiePlague.Data.ZClasses.Abilities;

public class Heal : IZAbility
{
    private bool IsActive = false;
    
    private readonly ISwiftlyCore _core;
    private IPlayer? _caster;
    private readonly Utils _utils;
    
    private const string ParticleEffectName = "particles/kolka/part2.vpcf";
    private const float TraceDistance = 3500f;
    private const float EyePositionZ = 64f;
    private const float ZeroPosition = 0f;

    private const int HealAmount = 500;

    public void SetCaster(IPlayer caster)
    {
        _caster = caster;
    }

    public void UnHookAbility()
    {
        _core.Event.OnClientKeyStateChanged -= OnClientKeyStateChanged;
    }

    public Heal(ISwiftlyCore core, Utils utils)
    {
        _core = core;
        _utils = utils;

        core.Event.OnClientKeyStateChanged += OnClientKeyStateChanged;
    }
    
    public void Use()
    {
        var casterPawn = _caster.RequiredPlayerPawn;
        var origin = casterPawn.CBodyComponent?.SceneNode?.AbsOrigin ?? Vector.Zero;
        var start = origin + new Vector(ZeroPosition, ZeroPosition, EyePositionZ);

        var viewAngles = casterPawn.EyeAngles;
        var forward = ForwardFromAngles(viewAngles);
        var end = start + forward * TraceDistance;

        var trace = new CGameTrace();

        _core.Trace.SimpleTrace(start, end, RayType_t.RAY_TYPE_LINE, RnQueryObjectSet.AllGameEntities | RnQueryObjectSet.Static,
            MaskTrace.Solid | MaskTrace.Player, MaskTrace.Empty, MaskTrace.Empty, CollisionGroup.Player, ref trace,
            casterPawn);
        
        var targetEntity = trace.Entity;
        var target = _utils.FindPlayerByPawnAddress(targetEntity.Address);
        
        if (target == null || !target.IsInfected())
        {
            return;
        }

        var targetPawn = target.RequiredPlayerPawn;
        
        var currentHp = targetPawn.Health;
        var newHp = currentHp + HealAmount;

        CreateParticle(target);
        
        target.SetHealth(newHp);
    }

    private void OnClientKeyStateChanged(IOnClientKeyStateChangedEvent @event)
    {
        if (IsActive)
        {
            return;
        }
        
        var player = _core.PlayerManager.GetPlayer(@event.PlayerId);

        if (player is not { IsValid: true } || !player.Controller.PawnIsAlive || !player.Equals(_caster))
        {
            return;
        }

        var isPressed = @event.Pressed;
        var key = @event.Key;

        if (key == KeyKind.E && isPressed)
        {
            Use();
        }
    }

    private void CreateParticle(IPlayer target)
    {
        IsActive = true;
        var pawn = target.RequiredPlayerPawn;
        var particle = _core.EntitySystem.CreateEntity<CParticleSystem>();
        particle.EffectName = ParticleEffectName;
        particle.StartActive = true;
        particle.DispatchSpawn();
        particle.Teleport(pawn.AbsOrigin, null, null);
        particle.AcceptInput("SetParent", "!activator", pawn, particle);
        particle.AcceptInput("SetParentAttachment","knife", pawn);
        
        var startTime = 0f;

        CancellationTokenSource token = null!;
        token = _core.Scheduler.RepeatBySeconds(0.1f, () =>
        {
            startTime += 0.1f;

            if (target == null && !target.Controller.PawnIsAlive)
            {
                IsActive = false;
                particle.Despawn();
                token.Cancel();
            }

            if (startTime >= 5 || !target.IsInfected() || !target.Controller.PawnIsAlive)
            {
                IsActive = false;
                particle.Despawn();
                token.Cancel();
            }
        });
    }

    private static Vector ForwardFromAngles(QAngle angles)
    {
        const float deg2Rad = MathF.PI / 180f;

        var pitch = angles.Pitch * deg2Rad;
        var yaw = angles.Yaw * deg2Rad;

        var cosPitch = MathF.Cos(pitch);

        return new Vector(
            cosPitch * MathF.Cos(yaw),
            cosPitch * MathF.Sin(yaw),
            -MathF.Sin(pitch)
        );
    }
}