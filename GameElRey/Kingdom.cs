using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey.Resources;

namespace GameElRey
{
    public class Kingdom
    {
        public string KingdomName { get; set; }
        public Army KingdomArmy { get; set; }
        public WorkForce KingdomWorkforce { get; }
        public Resource KingdomResource { get; set; }
        public Report KingdomReport { get; set; }

        public Kingdom(string Name, 
            Army army, 
            WorkForce workforce,
            Resource resource,
            Report report)
        {
            KingdomName = Name;
            KingdomArmy = army;
            KingdomWorkforce = workforce;
            KingdomResource = resource;
            KingdomReport = report;
        }

        public static List<Unit> GetKingdomArmyContent(Kingdom k1) // do this for things to reference them easier
        {
            return k1.KingdomArmy.ArmyContent;
        }

        public static void getKingdomInformation(Kingdom k1)
        {
            Prompts.KingdomReport(k1);
            Console.WriteLine("Kingdom Name: " + k1.KingdomName);
            Console.WriteLine("Kingdom Army size: " + k1.KingdomArmy.ArmyContent.Count);
            Console.WriteLine(" Swordsmen: " + k1.KingdomArmy.ArmyContent.Count);
            Console.WriteLine("Kingdom Resources");
            Console.WriteLine("     Food Amount: " + k1.KingdomResource.ResourceFood.FoodAmount);
            Console.WriteLine("     Gold Amount: " + k1.KingdomResource.ResourceGold.GoldAmount);

        }

    }
    }
