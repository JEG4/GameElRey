using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Statistic
    {
        public Level Level { get; set; }
        public int Precision { get; set; }
        public int Accuracy { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; } // range? 
        public int Intelligence { get; set; } // Gain experience faster, Stats increase faster as well
        public int Agility { get; set; }
        public int Mana { get; set; } // for magic fire/earth/wind/water swordsmen // swordmen can become magical with mana and intelligence
                                      // determined by how units are upgraded
        public int Formation { get; set; }
        public Hitpoints Hp { get; set; }

        public Statistic(Level level,
            int precision,
            int accuracy,
            int strength,
            int dexterity,
            int intelligence,
            int mana,
            int formation,
            int agility,
            Hitpoints hp)
        {
            Level = level;
            Precision = precision;// precision cannot be more than accuracy
            Accuracy = accuracy; // accuracy cannot be more than precision
            Strength = strength; // potential
            Dexterity = dexterity; // increases stats in general 
            Intelligence = intelligence;
            Formation = formation;
            Agility = agility;
            Hp = hp;
            Mana = mana;
        }

        //UpgradeStatistics
        //dexterity is range of archers
        // 

        // strength/power is amount of dashes
        //
        //----|---*----|---
        // low precision high accuracy 
        //----|--|---------
        // 
        //attack and collect
        // attack decided by precision and accuracy
        //unit collects

        public Statistic(Level level, Army army) // army level is average of all units
        {
            //get all unit levels from Army
            //
            Level = level;
        }

        public Statistic(Kingdom ks1)// kingdom Level is the average of all levels
        {


            //Level = ;
        }

        public Statistic()
        {

        }

        public Statistic(Level level) // army level is average of all units
        {
            Level = level;
        }

        public static int StatisticAttackCalculator(Statistic stats)
        {

            Random rand = new();
            return rand.Next(stats.Precision, stats.Accuracy);
        }

        public static int StatisticWorkerCalculator(Statistic stats)
        {
            Random rand = new();
            return rand.Next(stats.Precision, stats.Accuracy);
        }

        public static Statistic UnitPresetStatistic( string UnitType, string tier)
        {
            Random rand = new();

            //Get Training Center Statistic
            int bonus = TierBonus(tier);
            Upgrade.ColorNumber(bonus);
            if (UnitType == "SWORDSMEN")
            {
                int strength = rand.Next(16 + bonus, 23 + bonus);
                int accuracy = rand.Next(8 + bonus, 15 + bonus);
                int precision = rand.Next(0 + bonus, 5 + bonus);
                int BaseDexterity = rand.Next(5 + bonus, 7 + bonus);
                int BaseIntelligence = rand.Next(4 + bonus, 7 + bonus);
                int formation = 1;
                int agility = rand.Next(0 + bonus, 5 + bonus); 
                int maxHitpoint = rand.Next(20 + bonus, 25 + bonus);
                int mana = rand.Next(20 + bonus, 25 + bonus);
                Hitpoints hp = new Hitpoints(maxHitpoint, maxHitpoint);
                Level level = new Level(1, new Experience(0, 10));
                Console.WriteLine(
                    "\nLevel: " + level.CurrentLevel
                    + "  \nExperience: " + level.ExperienceLevel.CurrentExperience + "/" + level.ExperienceLevel.MaxExperience
                    + ", \nPrecision: " + precision
                    + ", \nAccuracy: " + accuracy
                    + ", \nStrength: " + strength
                    + ", \nDexterity: " + BaseDexterity
                    + ", \nIntelligence: " + BaseIntelligence
                    + ", \nFormation: " + formation
                    + ", \nAgility: " + agility
                    + ", \nHP: " + hp.CurrentHitpoints + "/" + hp.MaxHitpoints
                    + ", \nmana: " + mana);
                Console.BackgroundColor = ConsoleColor.Black;
                Statistic statistic = new Statistic(level,
                    precision,
                    accuracy,
                    strength,
                    BaseDexterity,
                    BaseIntelligence,
                    mana,
                    formation,
                    agility,
                    hp
                    );

                return statistic;
            }
            if (UnitType == "WORKER")
            {
                int strength = rand.Next(10, 15);
                int accuracy = rand.Next(5, 10);
                int precision = rand.Next(0, 1);
                int BaseDexterity = rand.Next(0, 5);
                int BaseIntelligence = rand.Next(7, 11);
                int formation = 1;
                int agility = 0;
                int maxHitpoint = rand.Next(20, 25);
                int mana = rand.Next(20, 25);
                Hitpoints hp = new Hitpoints(maxHitpoint, maxHitpoint);
                Level level = new Level(1, new Experience(0, 20));
                Statistic statistic = new Statistic(level,
                    precision,
                    accuracy,
                    strength,
                    BaseDexterity,
                    BaseIntelligence,
                    mana,
                    formation,
                    agility,
                    hp
                    );

                return statistic;
            }
            else
            {
                return new Statistic();
            }
        }

        public static Statistic UnitPresetStatistic()
        {
            Random rand = new();
            int strength = rand.Next(16, 23);
            int accuracy = rand.Next(3, 7);
            int precision = rand.Next(0, 2);
            int BaseDexterity = rand.Next(0, 3);
            int BaseIntelligence = rand.Next(4, 7);
            int formation = 1;
            int agility = rand.Next(0, 2);
            int maxHitpoint = rand.Next(10, 15);
            int mana = rand.Next(20, 25);
            Hitpoints hp = new Hitpoints(maxHitpoint, maxHitpoint);
            Level level = new Level(1, new Experience(0, 20));
            Console.WriteLine(
                "Level: " + level.CurrentLevel
                + ", Experience: " + level.ExperienceLevel.CurrentExperience + "/" + level.ExperienceLevel.MaxExperience
                + ", Prec: " + precision
                + ", accuracy: " + accuracy
                + ", strength: " + strength
                + ", Dexterity: " + BaseDexterity
                + ", Intelligence: " + BaseIntelligence
                + ", Formation: " + formation
                + ", Agility: " + agility
                + ", hitpoints: " + hp.CurrentHitpoints + "/" + hp.MaxHitpoints
                + ", mana: " + mana); ;
            Statistic statistic = new Statistic(level,
                precision,
                accuracy,
                strength,
                BaseDexterity,
                BaseIntelligence,
                mana,
                formation,
                agility,
                hp
                );

            return statistic;
        }

        public static Statistic StatisticUnitChecker(Statistic s)
        {
            if (s.Precision >= s.Accuracy)
            {
                Console.WriteLine("Presicion is greater than accuracy... fixing precision. ");
                int RemainderForAccuracy = s.Precision - s.Accuracy;
                s.Accuracy += RemainderForAccuracy;

            } if(s.Accuracy >= s.Strength)
            {
                Console.WriteLine("Accuracy is greater than strength... fixing strength. ");
                int RemainderForStrength = s.Accuracy - s.Strength;
                s.Strength =+ RemainderForStrength;

            } else
            {
                Console.WriteLine("Stats Upgraded.");

            }

            return s;
        }


        public static int TierBonus(string tier)
        {

            int bonus = 0;
            if (tier == "NPC")
            {
                bonus = 0;
            }
            if (tier == "COMMON")
            {
                bonus = 1;
            }
            if (tier == "POWERFUL")
            {
                bonus = 2;
            }
            if (tier == "RARE")
            {
                bonus = 3;
            }
            if (tier == "UNIQUE")
            {
                bonus = 4;
            }
            if (tier == "LEGENDARY")
            {
                bonus = 5;
            }
            if (tier == "HEROIC LEGENDARY")
            {
                bonus = 6;
            }
            if (tier == "MYTHICAL LEGENDARY")
            {
                bonus = 7;
            }
            if (tier == "SACRED LEGENDARY")
            {
                bonus = 8;
            }
            if (tier == "GRANDMASTER LEGENDARY")
            {
                bonus = 9;
            }

            return bonus;
        }
    }
}




            // when a statistic upgrade is calculated
            // ---|---------|----- // swordsmen strength 1-5 // 
            // 0  1         3    5  // default 3-5 each time unit upgraded
            //    Dext      intel if intel 3 
            // starting stats 1-5
            // 
            //


