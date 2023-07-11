using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey.Resources
{
    public class Resource
    {
        public Food ResourceFood { get; set; }
        public Gold ResourceGold { get; set; }

        public Resource(Food food, Gold gold)
        {
            ResourceFood = food;
            ResourceGold = gold;
        }

        //public Resource(){}

            public static int CollectFood(Statistic s)// like attack calc
        { // depnds on worker and time

            Random rand = new Random();
            int food = rand.Next(s.Precision, s.Accuracy);
            //Console.WriteLine("food collected: " + food);
            /*for (int i = 0; i < s.Strength; i++)
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
                if (i == food)
                {
                    Console.Write("*");
                }
            }*/

            return food;
        }

        public static int CollectGold(Statistic s)// like attack calc
        { // depnds on worker and time

            Random rand = new();
            int gold = rand.Next(s.Precision, s.Accuracy);
            //Console.WriteLine("Worker collected gold: " + gold);
            /*for (int i = 0; i < s.Strength; i++)
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
                if (i == gold)
                {
                    Console.Write("*");
                }
            }*/

            return gold;
        }

        public static Resource CollectResource(WorkForce wf)
        {
            Console.WriteLine("Collecting resources...");
            //"GOLD"
            //"FOOD"
            //"FORGE"
            //"BUILDER"
            int food = 0;
            int gold = 0;

            int size = wf.Worker.Count;
            Console.WriteLine("Worker count..." + size);
            for (int i = 0; i < size; i++)
            {
                Worker w = wf.Worker[i];// if miner then collect gold

                int FoodCollected = Resource.CollectFood(w.Stat);
                food = food + FoodCollected;
                //Console.WriteLine("Food Collected +" + FoodCollected);
            }

            for (int i = 0; i < size; i++)
            {
                Worker w = wf.Worker[i];// if miner then collect gold

                int GoldCollected = Resource.CollectGold(w.Stat);
                gold = gold + GoldCollected;
                //Console.WriteLine("Gold Collected +" + GoldCollected);
            }
            // +3
            Console.WriteLine("Total Food Collected " + food);
            Console.WriteLine("Total Gold Collected " + gold);

            return new Resource(new Food(food), new Gold(gold));
        }

        public static Resource AddResourceToKingdomResource(Kingdom k1)
        {
            Console.WriteLine("Collected resources is being added to kingdom...");
            Resource CollectedResources = Resource.CollectResource(k1.KingdomWorkforce);
            k1.KingdomReport.ResourceCollectionReport = CollectedResources;

            return new Resource(
                new Food(k1.KingdomResource.ResourceFood.FoodAmount + CollectedResources.ResourceFood.FoodAmount),
                new Gold(k1.KingdomResource.ResourceGold.GoldAmount + CollectedResources.ResourceGold.GoldAmount));
        }

        // how is cost calculated use actual exonomics
        // Creating Unit costs depend on default statistics
        // default statistics dependent on kingdom level/ Training Center level/ Army Level

        // resource spend depends on stats
        // create default swordsmen
        // each swordsmen can become special
        // create special swordsmen

        //
        // resource collect // will run on a thread
        //

        // upgrade timer?

    }
}
