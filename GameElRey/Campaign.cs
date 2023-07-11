using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Campaign
    {
        public Enemy CampaignEnemyUnits { get; set; }
        public Unit CampaignHero { get; set; }
        public int CampaignWave { get; set; }
        public Kingdom CampaignKingdom { get; private set; }

        public Campaign(Kingdom kingdom, Enemy Enemy, Unit Hero, int wave)
        {
            Kingdom CampaignKingdom = kingdom;
            CampaignEnemyUnits = Enemy;
            CampaignHero = Hero;
            CampaignWave = wave;
        }

        public static Unit SelectUnitForCampaign(Kingdom k1)
        {

            int size = k1.KingdomArmy.ArmyContent.Count;

            for(int i = 0; i < size; i++)
            {
                Console.WriteLine();
                Unit unit = k1.KingdomArmy.ArmyContent[i];// display unit information
                Console.Write(i + ". ");
                Display.UnitNameDisplay(unit);
                Console.WriteLine("Level: " + unit.Stats.Level.CurrentLevel);
                Console.WriteLine("Health " +unit.Stats.Hp.CurrentHitpoints +"/" + unit.Stats.Hp.MaxHitpoints);
                Console.WriteLine(" Prec: " + unit.Stats.Precision + ", accuracy: " + unit.Stats.Accuracy + ", strength: " + unit.Stats.Strength);
                Console.WriteLine(" ");


                //get unit at that array index with number input
            }
            Console.WriteLine("Decide which Unit for campaign. ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Unit unit1 = k1.KingdomArmy.ArmyContent[choice];

            Console.WriteLine("Hero "); 
            Display.UnitNameDisplay(unit1);
            Console.WriteLine(" Precision: " + unit1.Stats.Precision 
                + ", \naccuracy: " + unit1.Stats.Accuracy 
                + ", \nstrength: " + unit1.Stats.Strength);
            Console.WriteLine(" ");
            Console.WriteLine("  HAS BEEN CHOSEN  ");

            return unit1;
        }



        public static Kingdom EnterCampaign(Kingdom KingdomCampaign)
        {
            Enemy EnemyUnits = new Enemy(new List<Unit>()); // enemies army
            EnemyUnits.EnemyUnit = Enemy.AutogenerateEnemies();

            Console.WriteLine("Current kingdom army count: " + KingdomCampaign.KingdomArmy.ArmyContent.Count);
            Unit SelectedUnit = SelectUnitForCampaign(KingdomCampaign); //autogenerate 
            int FirstWave = 1;
            Campaign CampaignJourney = new Campaign(KingdomCampaign, EnemyUnits, SelectedUnit ,FirstWave);
            Console.WriteLine("Encountering wave "+ CampaignJourney.CampaignWave);
            //  fight enemies
            //  Upgrade 
            //  Equip


            Campaign UpdatedCampaignJourney = CampaignEnemyEncounter(CampaignJourney);// loop while i create the ending
            Console.WriteLine("From wave " + UpdatedCampaignJourney.CampaignWave); // current wave
            UpdatedCampaignJourney.CampaignWave = UpdatedCampaignJourney.CampaignWave + 1; // new wave
            Console.WriteLine("New Upcoming Wave " + UpdatedCampaignJourney.CampaignWave);
            NewEnemies(UpdatedCampaignJourney);
            //EnterCampaign(k1);

            return KingdomCampaign;
        }

        public static Campaign CampaignEnemyEncounter(Campaign CampaignEncounters)
        {

            Campaign UpdatedCampaignJourney = CampaignEncounters;

            Console.WriteLine("Inside Campaign Journey.");
            Enemy EnemyUnitsCampaignEncounters = CampaignEncounters.CampaignEnemyUnits;// place enemy army here

            Kingdom KingdomHero = CampaignEncounters.CampaignKingdom;



            while (EnemyUnitsCampaignEncounters.EnemyUnit.Count != 0) // 
            {
                Random r = new Random();
                int i = r.Next(0, EnemyUnitsCampaignEncounters.EnemyUnit.Count); // should be by 
                Unit SingleEnemy = EnemyUnitsCampaignEncounters.EnemyUnit[i]; //fighting random enemy 
                //Unit HeroUnit = CampaignEncounters.CampaignHero;// i dont have to create hero unit
                Unit SurvivingUnit = Battle.FightSequence(CampaignEncounters.CampaignHero, SingleEnemy);

                if (SurvivingUnit.UnitName == CampaignEncounters.CampaignHero.UnitName) // hero survived
                {
                    EnemyUnitsCampaignEncounters.EnemyUnit.Remove(SingleEnemy);
                    Display.UnitNameDisplay(SingleEnemy);
                    Console.WriteLine(" ENEMY HAS BEEN KILLED.");
                    Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignEncounters.EnemyUnit.Count);
                    LootDropped();
                    CampaignEncounters.CampaignHero = ExperienceGained(CampaignEncounters.CampaignHero);
                    CampaignEncounters.CampaignHero = RestHero(CampaignEncounters.CampaignHero);
                    Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignEncounters.EnemyUnit.Count);
                    Console.WriteLine("Hero has won the fight.");
                    // update hero unit


                } if (SurvivingUnit.UnitName == SingleEnemy.UnitName) // enemy survived
                {
                    Console.WriteLine("Enemy has won the fight.");
                    KingdomHero.KingdomArmy.ArmyContent.Remove(CampaignEncounters.CampaignHero); //remove hero from kingdom of campignencounter
                    CampaignEnd(CampaignEncounters.CampaignHero);
                    
                } 

                /*
                if (HeroUnit.Stats.Hp.CurrentHitpoints <= 0)
                {
                    k1.KingdomArmy.ArmyContent.Remove(HeroUnit);
                    CampaignEnd(HeroUnit);
                }
                else if (EnemyUnitsCampaignJourney.EnemyUnit[i].Stats.Hp.CurrentHitpoints <= 0)
                { 
                    EnemyUnitsCampaignJourney.EnemyUnit.Remove(SingleEnemy);
                    Display.UnitNameDisplay(SingleEnemy);
                    Console.WriteLine( " ENEMY HAS BEEN KILLED.");
                    Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignJourney.EnemyUnit.Count);
                    LootDropped();
                    HeroUnit = ExperienceGained(HeroUnit);
                    HealHero(HeroUnit);
                    Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignJourney.EnemyUnit.Count);

                }*/

            }
            CampaignEncounters.CampaignEnemyUnits = EnemyUnitsCampaignEncounters;//updating campaign enemies // should be 
            CampaignEncounters.CampaignKingdom = KingdomHero;//updating kingdom
            CampaignEncounters.CampaignWave = 1;//updating kingdom

            Console.WriteLine("Exiting Campaign Encounter");
            return UpdatedCampaignJourney;
            //CampaignEnd();
        }

        public static void CampaignNextWave()
        { 

        }

            /*
            public static void CampaignWaveFight()
            {
                Enemy EnemyUnitsCampaignJourney = SpiritualCampaign.CampaignEnemy;



                while (EnemyUnitsCampaignJourney.EnemyUnit.Count != 0)
                {
                    Random r = new Random();
                    int i = r.Next(0, EnemyUnitsCampaignJourney.EnemyUnit.Count);
                    Unit SingleEnemy = EnemyUnitsCampaignJourney.EnemyUnit[i];
                    Unit HeroUnit = SpiritualCampaign.CampaignHero;
                    Battle.Fight(HeroUnit, SingleEnemy);

                    if (HeroUnit.Stats.Hp.CurrentHitpoints <= 0)
                    {
                        k1.KingdomArmy.ArmyContent.Remove(HeroUnit);
                        CampaignEnd(HeroUnit);
                    }
                    else if (EnemyUnitsCampaignJourney.EnemyUnit[i].Stats.Hp.CurrentHitpoints <= 0)
                    {
                        EnemyUnitsCampaignJourney.EnemyUnit.Remove(SingleEnemy);
                        Console.WriteLine(SingleEnemy.UnitName + " ENEMY HAS BEEN KILLED.");
                        Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignJourney.EnemyUnit.Count);
                        LootDropped();
                        HeroUnit = ExperienceGained(HeroUnit);
                        HealHero(HeroUnit);
                        Console.WriteLine("Current enemy count: " + EnemyUnitsCampaignJourney.EnemyUnit.Count);

                    }
                }
            }*/


        public static Campaign NewEnemies(Campaign c)
        {
            int NewEnemyWave = c.CampaignWave; // get new wave

            if(c.CampaignEnemyUnits.EnemyUnit.Count == 0) //
            {
                Console.WriteLine("Creating and upgrading New units");
                Enemy EnemyUnits = new Enemy(new List<Unit>());
                EnemyUnits.EnemyUnit = Enemy.AutogenerateEnemies();
                // upgrade all enemies 
                for(int i = 0; i<=NewEnemyWave; i++)
                {
                    foreach (Unit Unit in EnemyUnits.EnemyUnit)
                    {
                        if (i == NewEnemyWave)
                        {
                            Console.WriteLine("Upgrading enemy ");
                            Display.UnitNameDisplay(Unit);
                        }
                        Upgrade.UpgradeUnit(Unit);
                    }
                }
                
                Console.WriteLine();
                Console.WriteLine("THE ENEMY HAS BECOME STRONGER.......");
                Console.WriteLine("==== Entering Wave " + NewEnemyWave + " =====");
                Console.WriteLine();

                c.CampaignEnemyUnits = EnemyUnits;
                return c;
            }
            else
            {
                Console.WriteLine("WAVE OF ENEMIES ARE STILL ALIVE");
                return c;
            }
        }

        public static void CampaignEnd(Unit HeroUnit)
        {
            Display.UnitNameDisplay(HeroUnit);
            Console.WriteLine(" CAMPAIGN HAS  ENDED. ");
        }

        public static void CampaignEnd()
        {
            Console.BackgroundColor = ConsoleColor.Red; 
            Console.ForegroundColor = ConsoleColor.Black;   
            Console.WriteLine();
            Console.WriteLine("|||||||||||||||||||||||||||");
            Console.WriteLine("|| All enemy units slain ||");
            Console.WriteLine("|||||||||||||||||||||||||||");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static Unit RestHero(Unit RestingHeroUnit)
        {
            Console.WriteLine();
            Console.WriteLine("Resting hero...");
            Display.UnitNameDisplay(RestingHeroUnit);
            Console.WriteLine();// healing magic should be a dice roll
            Console.WriteLine();// potion is preset based off money 
            int Health = RestingHeroUnit.Stats.Hp.CurrentHitpoints;
            if (Health < RestingHeroUnit.Stats.Hp.MaxHitpoints)
            {
                RestingHeroUnit.Stats.Hp.CurrentHitpoints = RestingHeroUnit.Stats.Hp.CurrentHitpoints + 10;
                if(RestingHeroUnit.Stats.Hp.CurrentHitpoints > RestingHeroUnit.Stats.Hp.MaxHitpoints)
                {
                    Display.UnitNameDisplay(RestingHeroUnit);
                    Console.WriteLine("Over rested.");
                    RestingHeroUnit.Stats.Hp.CurrentHitpoints = RestingHeroUnit.Stats.Hp.MaxHitpoints;
                } else {
                    Display.UnitNameDisplay(RestingHeroUnit);
                    Console.WriteLine(" Has restored 10 life.");
                    Console.WriteLine("HP: " + RestingHeroUnit.Stats.Hp.CurrentHitpoints + "/" + RestingHeroUnit.Stats.Hp.MaxHitpoints);
                    return RestingHeroUnit;
                }
                return RestingHeroUnit;
            }
            else
            {
                Console.WriteLine("Full HP");
                Console.WriteLine("HP: " + RestingHeroUnit.Stats.Hp.CurrentHitpoints + "/" + RestingHeroUnit.Stats.Hp.MaxHitpoints);// potion is preset based off money 
                return RestingHeroUnit;
            }
        }

        public static void LootDropped()
        {
            Console.WriteLine("LOOT DROPPED: ");

        }

        public static Unit ExperienceGained(Unit unit1)
        {
            Random r = new Random();
            
            int ExperienceGained = Upgrade.GainedExperienceCalculator(unit1); // if based off intelligence
                                                                                
            int i = r.Next(1, ExperienceGained);

            unit1.Stats.Level.ExperienceLevel.CurrentExperience = unit1.Stats.Level.ExperienceLevel.CurrentExperience + i;

            Console.WriteLine("Experience + " + i + " " +
                "New Experience: " + unit1.Stats.Level.ExperienceLevel.CurrentExperience
                + "/" + unit1.Stats.Level.ExperienceLevel.MaxExperience);

            if (unit1.Stats.Level.ExperienceLevel.CurrentExperience >= unit1.Stats.Level.ExperienceLevel.MaxExperience)
            {
                return Upgrade.UpgradeUnit(unit1);
            } else
            {
                return unit1;
            }
            
            
        }

        public static void EnterLevel()
        {

        }
    }
}
