using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class DiceRoll
    {
        public static int Roll(Statistic s)
        {

            Random rand = new Random();
            int rolled= rand.Next(s.Precision, s.Accuracy);
            for (int i = 0; i < s.Strength; i++)
            {
                Console.Write("-");
                if (i == s.Precision)
                {
                    Console.Write("|");
                }
                if (i == s.Accuracy)
                {
                    Console.Write("|");
                }
                if (i == rolled)
                {
                    Console.Write("*");
                }
            }
            return rolled;
        }
    }
}
