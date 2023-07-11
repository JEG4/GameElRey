using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Element
    {
        string ElementType { get; set; }    
        Element(string type)
        {
            ElementType = type;
        }

        public static string GenerateElement()
        {
            Console.WriteLine("");
            Random r = new Random();
            int i = r.Next(1, 5);
            if (i == 1)
            {
                Display.UnitElementDisplay("EARTH");
                return "EARTH";
            }
            if (i == 2)
            {
                Display.UnitElementDisplay("WIND");
                return "WIND";
            }
            if (i == 3)
            {
                Display.UnitElementDisplay("WATER");
                return "WATER";
            }
            if (i == 4)
            {
                Display.UnitElementDisplay("FIRE");
                return "FIRE";
            }
            else {
                Display.UnitElementDisplay("NON-ELEMENTAL"); 
                return "NON-ELEMENTAL"; }

        }
    }
}
