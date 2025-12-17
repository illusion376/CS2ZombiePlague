using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2ZombiePlague.Data.Classes
{
    public class ZombieHeavy : IZombieClass
    {
        public string IternalName => "zombie_heavy";
        public string DisplayName => "Zombie Heavy";
        public string ZombieModel => "characters/players/zombie_models/zombie_heavy/zombie_heavy.vmdl";
        public string ClawsModel => "characters/players/zombie_models/zombie_heavy/zombie_heavy_claws.vmdl";
        public int Health { get; set; } = 5000;
        public float Speed { get; set; } = 260.0f;
        public float Knockback { get; set; } = 1.0f;
        public int Gravity { get; set; } = 700;
    }
}
