using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2ZombiePlague.Helpers
{
    static public class Sound
    {
        // Проигрывает аудиозапись игроку
        public static void PlayLocalSound(this CCSPlayerController player, string soundPath)
        {
            if (player == null || !player.IsValid) return;

            player.ExecuteClientCommand($"play {soundPath}");
        }

    }
}
