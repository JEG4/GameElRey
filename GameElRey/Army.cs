using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Army
    {
        public List<Unit> ArmyContent { get; set; }
        public Army(List<Unit> a)
        {
            ArmyContent = a;
        }

        public static List<Unit> AddToArmy(List<Unit> a,Unit u)
        {
            // perhaps redundant once created run
            Console.WriteLine();
            Console.WriteLine("Army capacity before " + a.Count);
            Console.WriteLine("Adding unit:" + u.UnitType);
            a.Add(u);
            
            Console.WriteLine("Army capacity after " + a.Count);
            return a;
        }
    }
}
