using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsElRey.Battle;

namespace GameElRey
{
    public class Prompts
    {
        public static void MainMenu(Kingdom k1)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Battle");
            Console.WriteLine("3. Upgrade");
            Console.WriteLine("4. Unit Campaign");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Create.CreatePrompt(k1);
            }
            else if (choice == "2")
            {
                Battle.BattlePrompt(k1);
            }
            else if (choice == "3")
            {
                UpgradePrompt(k1);
            }
            else if (choice == "4")
            {
                Campaign.EnterCampaign(k1);
            }
            else
            {

            }
        }
            
        public static void KingdomReport(Kingdom k1)
        {

            int gold =
            k1.KingdomReport.ResourceCollectionReport.ResourceGold.GoldAmount;
            int food =
            k1.KingdomReport.ResourceCollectionReport.ResourceFood.FoodAmount;
            int swordsmen = 3;
            int magicSwordsmen = 2;

            Console.WriteLine("===================");
            Console.WriteLine("==Kingdom Report===");
            Console.WriteLine("===================");
            Console.WriteLine("Last hour: ");
            Console.WriteLine("Resources collected "+ 
                "+" +gold+" gold, " 
                +
                "+" +food+" food");
            
            Console.WriteLine("Army made +" 
                + swordsmen + " Swordsmen +" 
                + magicSwordsmen + " Magic Swordsmen +" 
                + 1 + " rare swordsmen +" 
                + 1 +" Legendary");
            Console.WriteLine("===================");
            Console.WriteLine("==Report END=======");
            Console.WriteLine("===================");

        }



        public static Kingdom UnitCreate(Kingdom k1)
        {
            // get kingdom resources
            // unit cost
            // prompt with costs
            // swordmen created
            // grabs information from kingdom to produce swordsmen
            Console.WriteLine("Create Unit Prompt");
            Console.WriteLine("1. Create Swordsmen");
            Console.WriteLine("2. Create Worker");
            //Console.WriteLine("2. Create Archer");
            //Console.WriteLine("3. Create Knight");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                //choose unit to create 
                Console.WriteLine("1. Swordsmen ");
                return Unit.CreateSwordsmen(k1);
            }

            else if (choice == "2")
            {
                Console.WriteLine("2. Worker ");
                return Worker.CreateWorker(k1);
            }
            else if (choice == "3")
            {
                Console.WriteLine("3. Knight ");
                return k1;
            }
            else
            {
                return k1;
            }
        }

        public static Kingdom WorkerCreate(Kingdom k1)
        {
            // get kingdom resources
            // unit cost
            // prompt with costs
            // swordmen created
            // grabs information from kingdom to produce swordsmen
            Console.WriteLine("Create Unit Prompt");
            Console.WriteLine("1. Create Gold Worker");
            Console.WriteLine("2. Create Food Worker");
            Console.WriteLine("3. Create Forge Worker");
            Console.WriteLine("3. Create Building Worker");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("1. Worker ");
                return Worker.CreateWorker(k1);
            }

            else if (choice == "2")
            {
                Console.WriteLine("2. Archer ");
                return k1;
            }
            else if (choice == "3")
            {
                Console.WriteLine("3. Knight ");
                return k1;
            }
            else
            {
                return k1;
            }
        }
        // upgrade units, technology, equipment
        public static Kingdom UpgradePrompt(Kingdom k1)
        {
            Console.WriteLine("Upgrade Prompt.");
            // upgrade requirements
            // monetary requirements
            // get kingdom resources accordingly
            // get kingdom statistics accordingly
            return k1;
        }
    }
}

