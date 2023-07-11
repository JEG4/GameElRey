using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Worker
    {
        Worker(string Type, Statistic Stat) //
        {    
            this.Type = Type; //blacksmiths, miners, farmers, trainers
            this.Stat = Stat;

            //Console.WriteLine(Type + " Worker Created.");// + Stat );
        }

        public string Type { get; set; }
        public Statistic Stat { get; set; }

        // upgrade worker if legendary worker build legendary forge

        public static Kingdom CreateWorker(Kingdom k)
        {

            Console.WriteLine(); // still need to program requirements
            Console.WriteLine("Enter Gold Worker amount: ");
            //int choice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                Worker w = new Worker("GOLD",
                Statistic.UnitPresetStatistic("WORKER", "COMMON"));
                k.KingdomWorkforce.Worker.Add(w);
            }

            for (int i = 0; i < 5; i++)
            {
                Worker w = new Worker("FOOD",
                Statistic.UnitPresetStatistic("WORKER", "COMMON"));
                k.KingdomWorkforce.Worker.Add(w);
            }

            return k;
        }



    }
}
