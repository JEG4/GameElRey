using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey.Resources;

namespace GameElRey
{
    public class StartElRey
    {
        public int kingdomID = 0;
 
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game El Rey ");
            Console.ForegroundColor = ConsoleColor.Gray;

            // WorkForce wf = new WorkForce();
            Names.AddUnitNames();

            Kingdom k1 = CreateKingdom();
            Worker.CreateWorker(k1).KingdomResource = Resource.AddResourceToKingdomResource(k1);
            Worker.CreateWorker(k1).KingdomResource = Resource.AddResourceToKingdomResource(k1);
            
            Kingdom.getKingdomInformation(k1);       
            Prompts.UnitCreate(k1); 
            Prompts.MainMenu(k1);
  
            

        }

        public static void addKingdomsToGame(Kingdom k)
        {
            //elReyKingdoms.Add(k);
        }

        public static Kingdom CreateKingdom()
        {
            Random rand = new Random();
            int i = rand.Next(0, 100000);
            string kID = i.ToString();
            string kingdomName = "Kingdom " + kID; 

            return new Kingdom(
                kingdomName,
                new Army(new List<Unit>()),
                new WorkForce(new List<Worker>()),
                new Resource(
                    new Food(100),
                    new Gold(100)),
                new Report(
                    new Resource(
                        new Food(7), 
                        new Gold(3))));
        }        
    }
}
