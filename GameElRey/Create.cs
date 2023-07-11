using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Create
    {
        public static Kingdom CreatePrompt(Kingdom k1)
        {
            Console.WriteLine("Create Prompt");
            Console.WriteLine("1. Create Unit");
            Console.WriteLine("2. Create Building");
            Console.WriteLine("3. Create ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {

                //choose unit to create 
                Console.WriteLine("Attempting to create unit ");
                return Prompts.UnitCreate(k1); ;// put into an array?

            }

            else if (choice == "2")
            {
                return k1;
            }
            else if (choice == "3")
            {

                Prompts.UpgradePrompt(k1);
                return k1;
            }
            else
            {
                return k1;
            }
        }
    }
}
