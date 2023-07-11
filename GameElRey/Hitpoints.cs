using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Hitpoints
    {
        public Hitpoints(int current, int max)
        {
            CurrentHitpoints = current;
            MaxHitpoints = max;
        }

        public int CurrentHitpoints { get; set; }
        public int MaxHitpoints { get; set;  }
    }
}
