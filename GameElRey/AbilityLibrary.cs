using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class AbilityLibrary
    {

        public List<Ability> AbilityList { get; set; }
        public AbilityLibrary(List<Ability> AbilityList)
        {
            this.AbilityList = AbilityList;
        }


        public static string GetDefenseAbility(Unit u) // from unit
        {
            // 4 abilities
            int i = u.UnitDefenseAbilities.AbilityList.Count;
            Random r = new Random();
            int AbilityIndex = r.Next(0, i);
            Console.WriteLine("Getting defense ability " + u.UnitDefenseAbilities.AbilityList[AbilityIndex].AbilityName + " at " + AbilityIndex);
            return u.UnitDefenseAbilities.AbilityList[AbilityIndex].AbilityName;
        }

        public static string GetAttackAbility(Unit u) // from unit
        {
            // 4 abilities
            int i = u.UnitAttackAbilities.AbilityList.Count;
            Random r = new Random();
            int AbilityIndex = r.Next(0, i);
            Console.WriteLine("Getting attack ability " + u.UnitAttackAbilities.AbilityList[AbilityIndex].AbilityName + " at " + AbilityIndex);
            return u.UnitAttackAbilities.AbilityList[AbilityIndex].AbilityName;
        }

        public static AbilityLibrary GenerateDefenseAbility()
        {
            AbilityLibrary GeneratedAbilities = new AbilityLibrary(new List<Ability>());

            GeneratedAbilities.AbilityList.Add(new Ability("DODGE", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("EVADE", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("BLOCK", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("ABILITY PREVENTION", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("HEAL", new Level(1, new Experience(0, 10))));

            foreach (Ability ability in GeneratedAbilities.AbilityList)
            {
                Console.WriteLine("Defense Ability generated: " + ability.AbilityName);
            }
            return GeneratedAbilities;
        }

        public static AbilityLibrary GenerateAttackAbility()
        {
            AbilityLibrary GeneratedAbilities = new AbilityLibrary(new List<Ability>());

            GeneratedAbilities.AbilityList.Add(new Ability("POWER STRIKE", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("IMPALE", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("SMITE", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("AURA OF DESTRUCTION", new Level(1, new Experience(0, 10))));
            GeneratedAbilities.AbilityList.Add(new Ability("AURA OF CANCELLATION", new Level(1, new Experience(0, 10))));

            foreach (Ability ability in GeneratedAbilities.AbilityList)
            {
                Console.WriteLine("Attack Ability generated: " + ability.AbilityName);
            }
            return GeneratedAbilities;
        }
    }
}
