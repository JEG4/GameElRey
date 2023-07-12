using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Unit
    {
        public string UnitElement { get; set; }
        public string UnitTier { get; set; }
        public string UnitName { get; set; }

        public string UnitType { get; set; }
        public Statistic Stats { get; set; }
        public Equipment Equip { get; set; }
        public AbilityLibrary UnitDefenseAbilities { get; set; }

        public AbilityLibrary UnitAttackAbilities { get; set; }
        public Condition UnitCondition { get; set; }
        
            
         public Unit(string element, 
             string tier,
             string name,
             string type,
             Statistic stats,
             Equipment equip,
             AbilityLibrary DefenseAbilities, 
             AbilityLibrary AttackAbilities, 
             Condition condition)
        {

            UnitElement= element;
            UnitTier = tier;
            UnitName = name;
            UnitType = type;
            Stats = stats;
            Equip = equip;
            UnitDefenseAbilities = DefenseAbilities;
            UnitAttackAbilities = AttackAbilities;
            UnitCondition = condition;
        }


        public static Kingdom CreateSwordsmen(Kingdom k)
        {
            Console.WriteLine(); // still need to program requirements
            Console.WriteLine("Enter Swordsmen amount: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < choice; i++)
            {
                string SwordsmenName = GenerateUnitName();
                string Swordsmentier = GenerateSwordsmenTier(SwordsmenName);
                string SwordsmenElement = Element.GenerateElement();
                List<Ability> abilityList = new List<Ability>();

                Unit Swordsmen = new Unit(SwordsmenElement,
                    Swordsmentier,
                    SwordsmenName, 
                    "SWORDSMEN",
                Statistic.UnitPresetStatistic(
                    "SWORDSMEN", 
                    Swordsmentier),
                new Equipment(
                    "SWORD", 
                    new Statistic()),
                AbilityLibrary.GenerateDefenseAbility(),
                AbilityLibrary.GenerateAttackAbility(),
                new Condition(new List<string>())
                );

                k.KingdomArmy.ArmyContent.Add(Swordsmen);
                Console.WriteLine("Swordsmen created. ");
            }

            return k;
        }

        public static Unit CreateEnemyUnit() {
            Random rand = new();
            int number = rand.Next(0, 100);

            Unit EnemyUnit = new Unit("NON-ELEMENTAL","NPC","ENEMY" + number, "MONSTER",
                Statistic.UnitPresetStatistic(),
                new Equipment("SWORD", new Statistic()), AbilityLibrary.GenerateAttackAbility(), AbilityLibrary.GenerateDefenseAbility(), new Condition(new List<string>()));

            Console.WriteLine(EnemyUnit.UnitName + "  Has been created.");

            return EnemyUnit;
        }

        /*public static Kingdom CreateSwordsmenTest(Kingdom k, int choice)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Swordsmen amount: ");

            Unit Swordsmen = new Unit("elemental test","Test Swordsmen", Unit.GenerateUnitName(), "SWORDSMEN",
               GenerateUnitStatistic(),
                new Equipment("SWORD", new Statistic()), 
                Ability.GenerateAbility(),
                new Condition(new List<string>()));

            for (int i = 0; i < choice; i++)
            {
                k.KingdomArmy.ArmyContent.Add(Swordsmen);
                Console.WriteLine("Swordsmen created. ");
            }

            return k;
        }


        /*public static Statistic GenerateUnitStatistic()
        {
            // get information from kingdom technology or something like that
            // generate default unit stat
            Statistic s = new(
                new Level(1,
                new Experience(0, 10)),
                5,
                15,
                30,
                10,
                11,
                12,
                1,
                new Hitpoints(100, 100));
            Console.WriteLine("Prec: " + s.Precision + ", accuracy: " + s.Accuracy + ", strength: " + s.Strength);
            return s;
        }*/

        // unit is created into worker/swordsmen/archer/knight
        // 200 / 130 
        //
        // worker:80
        // swordsmen:30
        // archer:10
        // knight:10

        // Resources
        // Food: 100
        // Gold: 300

        // Food Stats:
        // Worker: 40
        // collection rate: 30/hour
        // Statistics: 
        // created by upgrades
        // Fishing Boats
        // Farm
        // // unit collects
        public static void UnitSwordsmenCounter(Kingdom k1)
        {
            int ArmySize = k1.KingdomArmy.ArmyContent.Count;
            int SwordsmenCounter = 0;

            for (int i = 0; i < ArmySize; i++)
            {
                if (k1.KingdomArmy.ArmyContent[i].UnitType == "SWORDSMEN")
                {
                    SwordsmenCounter++;
                }
            }


            // count only swordsmen
            // for loop through array
            // count each "swordsmen"


            // sort through int formation
            // formation can change 1-5 


            Console.WriteLine("     Swordsmen Amount: " + SwordsmenCounter);
        }

        public static string GenerateUnitName()
        {
            // create a lot of names for units
            // even custom names
            string UnitName = Names.GetUnitName();
            //Console.Out.WriteLine(UnitName);
            return UnitName;
        }

        public static string GenerateSwordsmenTier(string u)
        {
            // randomly decided sorta
            // could be based off training center trainers as well
            // Will begin very default


            // return unit with name and tier

            Console.WriteLine("");
            Random r = new Random();
            int i = r.Next(1, 384);
            if (i < 24)
            {
                //Console.WriteLine(" Legendary dice roll. ");
                return LegendaryDiceRoll(u);
            }
            if (i >= 24 && i <= 62)
            {
                //Console.Write(" Rare dice roll +4");
                return ColorNumber(4, u);
            }
            if (i > 62 && i <= 124)
            {
                //Console.Write(" Magical dice roll +3");
                return ColorNumber(3, u);
            }
            if (i > 124 && i <= 224)
            {
                //Console.Write(" powerful dice roll +2");
                return ColorNumber(2, u);
            }
            if (i > 224 && i <= 385)
            {
                //Console.Write(" Common dice roll +1");
                return ColorNumber(1, u);
            }
            Console.WriteLine("What happened? " + i);

            return u;
        }

        public static string ColorNumber(int color, string u)
        {

            if (color == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("NPC");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return "NPC";

            }

            if (color == 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("COMMON");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return "COMMON";

            }
            if (color == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("POWERFUL");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return "POWERFUL";

            }
            if (color == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("RARE");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return "RARE";

            }
            if (color == 4)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("UNIQUE");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return "UNIQUE";
            }
            if (color == 5)
            {
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("LEGENDARY");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return "LEGENDARY";

            }
            if (color == 6)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("HEROIC LEGENDARY");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return "HEROIC LEGENDARY";

            }
            if (color == 7)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("MYTHICAL LEGENDARY");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return "MYTHICAL LEGENDARY";

            }
            if (color == 8)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("SACRED LEGENDARY");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return "SACRED LEGENDARY";

            }
            if (color == 9)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("GRANDMASTER LEGENDARY");
                Console.Write(" " + u + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                return "GRANDMASTER LEGENDARY";

            }

            else { return ""; }
        }

        public static string LegendaryDiceRoll(string u)
        {
            Random r = new Random();
            int i = r.Next(1, 100);
            if (i == 1)
            {
                return ColorNumber(9, u);
            }
            if (i > 1 && i <= 2)
            {
                return ColorNumber(8, u);
            }
            if (i > 2 && i <= 5)
            {
                return ColorNumber(7, u);
            }
            if (i > 10 && i <= 25)
            {

                return ColorNumber(6, u);
            }
            if (i > 25 && i <= 100)
            {

                return ColorNumber(5, u);
            }
            Console.WriteLine("Legendary what happened? " + i);
            return "WHAT HAPPENED TO THE LGNDRY??";

        }

    }

}
