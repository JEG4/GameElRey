using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Forge
    {
        //create equipment
        //  each with its own stats
        // Unit has an attack ----|--*--|----
        //                           8  10  13
        //                           
        // base attack: 10
        //  magic, unique, legendary, set
        //upgrade current equipment
        public List<Equipment> Equipment { get; set; }

        public Forge(List<Equipment> equipment)
        {
            Equipment = equipment;
        }



        public static void CreateItem(Kingdom k1)// items can be carried by worker to
        {
            // get k1 requirements to create items
            Console.WriteLine(); // still need to program requirements
            Console.WriteLine("Which item would you like to create? ");
            // int choice = Convert.ToInt32(Console.ReadLine()); // add later

            Console.WriteLine("Create sword");
            Console.WriteLine("How many swords?");
            int SwordAmount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < SwordAmount; i++) { }
            ///k1.KingdomInfrastructue.InfrastructureBuilding.CreateSword();
        }



        public static Equipment CreateSword()
        {

            Equipment sword = new Equipment("SWORD", new Statistic()); // weapon statistics

            // 31 swords: 15 swords 10 magical swords and 1 legendary
            return sword;
        }



        public static Equipment UpgradeEquipment(Equipment e, Kingdom k)
        {
            // how many do you want upgraded
            // if statements to check 
            // require money 
            // get kingdom worker blacksmith
            // 



            return e;
        }

    }
}
// item stats 
// attack + item stats 3 attack
// 30 + 3
// attack, speed, 
// speed increases amount of time 
// stamina is like hit point
// uses amount of stamina determined by statistics as well
// when stamina runs out unit can no longer hit
// properties
// increase unit stats
// 