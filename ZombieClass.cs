using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2ZombiePlague
{
    abstract public class ZombieClass
    {
        public abstract string DisplayName { get; set; }
        public abstract string IternalName { get; set; }
        public abstract int Health {  get; set; }
        public abstract float Speed { get; set; }
        public abstract float  Gravity { get; set; }
    }
}
