using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Names
    {


        public static List<string> UnitNames = new List<string>();  

        public static string GetUnitName() // global object
        {
            

            Random rand = new Random();
            int choice = rand.Next(0, UnitNames.Count -1);

            string UnitName = UnitNames[choice];

            UnitNames.RemoveAt(choice);
            Console.WriteLine("Name List Size: " + UnitNames.Count);


            return UnitName;

        }

        public static List<string> AddUnitNames()
        {

            UnitNames.Add("Johannes Liechtenauer ");
            UnitNames.Add("Sigmund Ringeck ");
            UnitNames.Add("Fiore dei Liberi ");
            UnitNames.Add("Kamiizumi Nobutsuna ");
            UnitNames.Add("Sasaki Kojiro ");
            UnitNames.Add("Miyamoto Musashi ");
            UnitNames.Add("Donald McBane ");
            UnitNames.Add("Joseph Bologne ");
            UnitNames.Add("Bill1 ");
            UnitNames.Add("Zephyr Blackthorn");
            UnitNames.Add("Orion Vanguard");
            UnitNames.Add("Elysium Steelheart");
            UnitNames.Add("Solara Frostblade");
            UnitNames.Add("Corvus Shadowstrike");
            UnitNames.Add("Nova Ironclad");
            UnitNames.Add("Draven Starbane");
            UnitNames.Add("Astrid Moonchaser");
            UnitNames.Add("Cypher Nightwind");
            UnitNames.Add("Ragnar Firestorm");
            UnitNames.Add("Seraphina Swiftblade");
            UnitNames.Add("Blade Valerius");
            UnitNames.Add("Azure Frostfang");
            UnitNames.Add("Nymphadora Voidshadow");
            UnitNames.Add("Grim Wraithbringer");
            UnitNames.Add("Maven Stormcloak");
            UnitNames.Add("Astra Starbright");
            UnitNames.Add("Voltage Thunderstrike");
            UnitNames.Add("Lyra Dawnblade");
            UnitNames.Add("Dante Bloodraven");
            UnitNames.Add("Astraea Sunfire");
            UnitNames.Add("Nyx Shadowweaver");
            UnitNames.Add("Valor Steelblade");
            UnitNames.Add("Aurora Stormcaster");
            UnitNames.Add("Theron Silverthorn");
            UnitNames.Add("Vesper Blacksteel");
            UnitNames.Add("Electra Moonshadow");
            UnitNames.Add("Ebon Obsidian");
            UnitNames.Add("Phoenix Vanguard");
            UnitNames.Add("Blade Shadowhand");
            UnitNames.Add("Rune Darkstar");
            UnitNames.Add("Vyra Swiftstrike");
            UnitNames.Add("Zarion Frostfire");
            UnitNames.Add("Kyra Starheart");
            UnitNames.Add("Ravyn Eclipse");
            UnitNames.Add("Argo Nightblade");
            UnitNames.Add("Luna Celestia");
            UnitNames.Add("Havoc Stormrider");
            UnitNames.Add("Asher Ironsoul");
            UnitNames.Add("Aveline Stargazer");
            UnitNames.Add("Talon Shadowthorn");
            UnitNames.Add("Nova Skyslash");
            UnitNames.Add("Nyx Shadowwalker");
            UnitNames.Add("Draven Frostfang");
            UnitNames.Add("Vex Midnight");
            UnitNames.Add("Celeste Sunblade");
            UnitNames.Add("Caliban Shadowthorn");
            UnitNames.Add("Aurora Thornheart");
            UnitNames.Add("Storm Swiftstrike");
            UnitNames.Add("Valeria Darkmoon");


            Console.WriteLine("Name List Size: "+UnitNames.Count);

            return UnitNames;
        }
    }
}
