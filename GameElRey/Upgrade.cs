using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    //upgrade engine
    public class Upgrade
    {
        public static Unit UpgradeUnit(Unit unit1)
        {
            Console.WriteLine();
            Console.WriteLine("Upgrading unit: " + unit1.UnitName +". ");
            unit1.Stats.Level.CurrentLevel = unit1.Stats.Level.CurrentLevel + 1;
            Console.WriteLine(unit1.UnitName + " has gained a new level " + unit1.Stats.Level.CurrentLevel);

            unit1.Stats.Strength = unit1.Stats.Strength + UpgradeDiceRoll();
            Console.WriteLine(" New Strength " + unit1.Stats.Strength);

            unit1.Stats.Accuracy= unit1.Stats.Accuracy + UpgradeDiceRoll();

            Console.WriteLine(" New Accuracy " + unit1.Stats.Accuracy);

            unit1.Stats.Precision= unit1.Stats.Precision + UpgradeDiceRoll();
            Console.WriteLine(" New Precision " + unit1.Stats.Precision);

            unit1.Stats.Hp.MaxHitpoints = unit1.Stats.Hp.MaxHitpoints + UpgradeDiceRoll();
            Console.WriteLine(" New Max HP " + unit1.Stats.Hp.MaxHitpoints);

            unit1.Stats.Intelligence = unit1.Stats.Intelligence + UpgradeDiceRoll();
            Console.WriteLine(" New Intelligence " + unit1.Stats.Intelligence);

            unit1.Stats.Dexterity = unit1.Stats.Dexterity + UpgradeDiceRoll();
            Console.WriteLine(" New Dexterity " + unit1.Stats.Dexterity);

            unit1.Stats.Level.ExperienceLevel.MaxExperience = MaxExperienceCalculator(unit1);
            Console.WriteLine(" New Max Experience " + unit1.Stats.Level.ExperienceLevel.MaxExperience);
            Console.WriteLine();

            Statistic.StatisticUnitChecker(unit1.Stats);// precision < accuracy < strength

            return unit1;
        }

        public static int UpgradeDiceRoll()
        {
            Console.Write(" Upgrade");
            Random r = new Random();
            int i = r.Next(1, 384);
            if(i < 24)
            {
                //Console.WriteLine(" Legendary dice roll. ");
                return LegendaryDiceRoll();
            }
            if(i >= 24 && i <= 62)
            {
                //Console.Write(" Rare dice roll +4");
                return ColorNumber(4);
            }
            if (i > 62 && i <= 124)
            {
                //Console.Write(" Magical dice roll +3");
                return ColorNumber(3);
            }
            if (i > 124 && i <= 224)
            {
                //Console.Write(" powerful dice roll +2");
                return ColorNumber(2);
            }
            if (i > 224 && i <= 385)
            {
                //Console.Write(" Common dice roll +1");
                return ColorNumber(1);
            }
            Console.WriteLine("What happened? " + i);

            return ColorNumber(0);
        }

        public static int LegendaryDiceRoll()
        {
            Random r = new Random();
            int i = r.Next(1, 100);
            if (i == 1)
            {
                return ColorNumber(9);
            }
            if (i > 1 && i <= 2 )
            {
                return ColorNumber(8);
            }
            if (i > 2 && i <= 5)
            {
                return ColorNumber(7);
            }
            if (i > 10 && i <= 25)
            {
                
                return ColorNumber(6);
            }
            if (i > 25 && i <= 100)
            {
                
                return ColorNumber(5);
            }
            Console.WriteLine("Legendary what happened? " +i);
            return i;

        }

        public static int GainedExperienceCalculator(Unit u)
        {
            int intelligence = u.Stats.Intelligence;
            //                             max int 9
            //[                   ][   ][ ][]
            //

            //Console.WriteLine("Maximum experience that can be gained: " + intelligence);


            List<int> Boundaries = FibFunction(intelligence);

            Console.WriteLine("Current Experience");
            Random r = new Random();
            int i = r.Next(1, intelligence);
            if ((i == intelligence) && (i > Boundaries[0]))
            { 
                Console.WriteLine(" Legendary dice roll");
                return i;
            }
            if (i <= Boundaries[0] && i > Boundaries[1])
            {
                Console.WriteLine(" Rare dice roll");
                return i;
            }
            if (i <= Boundaries[1] && i > Boundaries[2])
            {
                Console.WriteLine(" Magical dice roll");
                return i;
            }
            if (i <= Boundaries[2] && i > Boundaries[3])
            {
                Console.WriteLine(" powerful dice roll");
                return i;
            }
            if (i <= Boundaries[3] && i > Boundaries[4])
            {
                Console.WriteLine(" Common dice roll");
                return i;
            }
            return i;
        }

        public static List<int> FibFunction(int intelligence) {

            Console.WriteLine("Inside fib function...");
            List<int> BoundaryNumbers = new List<int>{intelligence};
            for (int i = 0; i < 5; i++)
            {
                //Console.Write(" " +intelligence + " ");
                int boundary = intelligence / 2;
                int upperBoundary = boundary + (boundary / 2);
                BoundaryNumbers.Add(boundary);
                intelligence = upperBoundary;
                Console.Write(" " + BoundaryNumbers[i]);
            }

            return BoundaryNumbers;

            //[  5   ][  5  ]
            // 5/2 = 2 
            // 5+2 = 7
            // 10 - 7 = 3
            //[    7   ][ 3 ]
        }

        public static List<int> FibFunctionForMaxExperience(int maxExperience)
        {

            Console.WriteLine("Inside fib function...");
            List<int> BoundaryNumbers = new List<int>();
            BoundaryNumbers.Add(maxExperience);
            for (int i = 0; i < 5; i++)
            {
                //Console.Write(" " +intelligence + " ");
                int boundary = maxExperience / 2;
                int upperBoundary = boundary + (boundary / 2);
                BoundaryNumbers.Add(boundary);
                maxExperience = upperBoundary;
                Console.Write(" " + BoundaryNumbers[i]);
            }

            return BoundaryNumbers;

            //[  5   ][  5  ]
            // 5/2 = 2 
            // 5+2 = 7
            // 10 - 7 = 3
            //[    7   ][ 3 ]
        }


        public static int MaxExperienceCalculator(Unit u)
        {
            Console.WriteLine("New max experience function!!");
            // 1000
            // 1000+750 =1750
            //  1750 / 2 = 875 =2625
            int AddingMaxExperience = u.Stats.Level.ExperienceLevel.CurrentExperience / 2;
            Console.WriteLine("Adding to max experience" + AddingMaxExperience);

            return u.Stats.Level.ExperienceLevel.MaxExperience + AddingMaxExperience;

            /*Console.WriteLine("based off level!");
            FibFunctionForMaxExperience(u.Stats.Level.ExperienceLevel.CurrentExperience);
            Console.WriteLine("Max experience");
            Random r = new Random();
            int i = r.Next(1,);
            if (i == 1 && i < 24)
            {
                Console.WriteLine(" Legendary dice roll");
                return 7;
            }
            if (i >= 24 && i <= 62)
            {
                Console.WriteLine(" Rare dice roll");
                return 14;
            }
            if (i > 62 && i <= 124)
            {
                Console.WriteLine(" Magical dice roll");
                return 21;
            }
            if (i > 124 && i <= 224)
            {
                Console.WriteLine(" powerful dice roll");
                return 28;
            }
            if (i > 224 && i <= 385)
            {
                Console.WriteLine(" Common dice roll");
                return 35;
            }
            return i;*/
        }

        public static int ColorNumber(int color)
        {

            if (color == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 0 ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 1;

            }

            if (color == 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" +1 ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 1;

            }
            if (color == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" +2 ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 2;

            }
            if (color == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" +3 ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 3;

            }
            if (color == 4)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" +4 ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 4;

            }
            if (color == 5)
            {
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("+5");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return 5;

            }
            if (color == 6)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("+6");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return 6;

            }
            if (color == 7)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("+7");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return 7;

            }
            if (color == 8)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("+8");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return 8;

            }
            if (color == 9)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("+9");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return 9;

            }

            else { return 0; }
        } 
        /*     Common                Magical       Legendary   
             * [         1-2        ][   3  ][ 4  ][5]
             *///                            Unique

    }
    }
