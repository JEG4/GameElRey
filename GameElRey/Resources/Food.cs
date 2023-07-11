using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey.Resources
{
    public class Food
    {
        public int FoodAmount { get; set; }

        public Food(int amount)
        {
            FoodAmount = amount;
        }

        // worker collects food
    }
}
