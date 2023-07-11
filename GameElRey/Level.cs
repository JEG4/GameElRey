using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Level
    {
        public int CurrentLevel { get; set; }
        public Experience ExperienceLevel { get; set; }

        public Level(int current, Experience exp)
        {
            CurrentLevel = current;
            ExperienceLevel = exp;
        }

        public Level(int current)
        {
            CurrentLevel = current;
        }

    }
}
