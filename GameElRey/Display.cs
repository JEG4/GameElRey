using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
   public class Display
    {

        public static void UnitElementDisplay(string u)
        {
            if (u == "FIRE")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("FIRE");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u == "EARTH")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("EARTH");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u == "WIND")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("WIND");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u == "WATER")
            {
                
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("WATER");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u == "NON-ELEMENTAL")
            {
                Console.Write("NON-ELEMENTAL");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

            public static void UnitNameDisplay(Unit u)
        {
            if(u.UnitTier == "COMMON")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                
            }
            if (u.UnitTier == "POWERFUL")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                
            }
            if (u.UnitTier == "RARE")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
               
            }
            if (u.UnitTier == "UNIQUE")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                     }
            if (u.UnitTier == "LEGENDARY")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u.UnitTier == "HEROIC LEGENDARY")
            {

                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u.UnitTier == "MYTHICAL LEGENDARY")
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u.UnitTier == "EPIC LEGENDARY")
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (u.UnitTier == "GRANDMASTER LEGENDARY")
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
               
            } if(u.UnitTier == "NPC")
            {
                Console.Write(u.UnitTier + " " + u.UnitName + " ");
            }

        }
        public static void UnitInformationDisplay()
        {

        }

        public static void FightDisplay(int DamageDone)
        {

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Damage done " + DamageDone);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");

        }
        public static void FightDisplay(Unit defender)
        {
            Console.Write("");
            Display.UnitNameDisplay(defender);
            Console.Write(" HP " + defender.Stats.Hp.CurrentHitpoints + "/" + defender.Stats.Hp.MaxHitpoints);
            Console.WriteLine();

        }

        public static void FightDisplay(Unit attacker, Unit defender)
        {
            Console.WriteLine();
            Display.UnitNameDisplay(attacker);
            Console.Write(" Attacks ");
            Display.UnitNameDisplay(defender);
            Console.WriteLine();

        }
    }
}
