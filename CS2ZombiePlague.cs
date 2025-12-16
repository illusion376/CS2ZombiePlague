using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Utils;
using CS2ZombiePlague.Helpers;

namespace CS2ZombiePlague
{
    public class CS2ZombiePlague : BasePlugin
    {
        public override string ModuleName => "CS2ZombiePlague";
        public override string ModuleVersion => "0.0.1";

        public override void Load(bool hotReload)
        {
            RegisterListener<Listeners.OnServerPrecacheResources>((manifest) =>
            {
                manifest.AddResource("sounds/countdown/women_countdown.vsnd");
            });

            RegisterEventHandler<EventRoundStart>(OnRoundStart);

        }

        private HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
        {
            var players = Utilities.GetPlayers();
            players.ForEach(player =>
            {
                player.PlayLocalSound("sounds/countdown/women_countdown.vsnd");
            });

            return HookResult.Continue;
        }
    }
}
