using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2ZombiePlague.Data.Classes
{
    public interface IZombieClass
    {
        string IternalName { get; }
        string DisplayName { get; }
        string ZombieModel { get; }
        string ClawsModel { get; }
        int Health { get; set; }
        float Speed { get; set; }
        float Knockback { get; set; }
        int Gravity { get; set; }

    }
}
