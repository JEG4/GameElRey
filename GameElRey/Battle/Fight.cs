using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey;

namespace TacticsElRey.Battle
{
    public class Fight : Battle
    {
        public Unit FightUnitAttacker { get; set; }
        public Unit FightUnitDefender { get; set; }
        public int FightUnitDamageDone { get; set; }
        public Fight(Unit unit1, Unit unit2, int damage){
            FightUnitAttacker = unit1;
            FightUnitDefender = unit2;
            FightUnitDamageDone = damage;

        }
        public static Fight AttackTurn(Fight FightingUnits)
        {
            Console.WriteLine();
            Console.WriteLine();
            // later: swords is base of attack
            Unit attacker = FightingUnits.FightUnitAttacker;
            Unit defender = FightingUnits.FightUnitDefender;
            FightingUnits.FightUnitDamageDone = HitpointCalculator(AttackCalculator(attacker),
                DefenseCalculator(defender));

            Fight UpdatedFightingUnitsAbilityAndDamageDone = AbilitySequenceCalculator(FightingUnits);// not being placed anywhere

            return FightingUnits;
        }

        public static Fight AbilitySequenceCalculator(Fight FightingUnits)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("New ability sequence calculator. Inside Fight Class.");
            int AttackerSpeed = SpeedCalculator(FightingUnits.FightUnitAttacker.Stats);
            int DefenderSpeed = SpeedCalculator(FightingUnits.FightUnitDefender.Stats);

            if (AttackerSpeed > DefenderSpeed)
            {

                Console.WriteLine("Attacker is faster " + AttackerSpeed);
                AbilityCalculator.AttackAbilityCalculator(FightingUnits);
                Console.WriteLine("");
                AbilityCalculator.DefenseAbilityCalculator(FightingUnits);
                return FightingUnits;
            }
            if (DefenderSpeed > AttackerSpeed)
            {
                Console.WriteLine("Defender is faster " + DefenderSpeed);
                AbilityCalculator.DefenseAbilityCalculator(FightingUnits);
                Console.WriteLine("");
                AbilityCalculator.AttackAbilityCalculator(FightingUnits);
                return FightingUnits;
            }
            if (DefenderSpeed == AttackerSpeed)
            {

                Console.WriteLine("Same speed recalculating.");
                AbilitySequenceCalculator(FightingUnits);
                return FightingUnits;
            }
            else
            {
                Console.WriteLine("Something weird happened");
                return null;
            }
        }

        /*
            AgilityCalculator(){
                -------- str 7
                -----||| agi 6
                1 == quicker
                // tie breaker is a coin flip

                ------- str 8
                ---|||| agi 3
                4 == slower
            }
         
         */
        public static int SpeedCalculator(Statistic s)
        {
            int strength = s.Strength;
            int Agility = 0;

            if (Agility < strength)
            {
                Random rand = new Random();
                int target = rand.Next(Agility, strength); // --*--| = speed 2
                int speed = target - Agility;
                return speed;
            }
            if (Agility >= strength)
            {
                Random rand = new Random();                //   3       11 
                int target = rand.Next(strength, Agility); // --|______| = 9
                int speed = target;
                return speed;
            }
            return 0;// no speed

        }

        public static int AttackCalculator(Unit AttackingUnit)
        {

            Console.WriteLine("Attacking Unit is: ");
            Random rand = new Random();
            int attack = rand.Next(AttackingUnit.Stats.Precision, AttackingUnit.Stats.Accuracy);
            Display.FightDisplay(AttackingUnit);
            Console.Write("\t\t\tAttack: " + attack);
            for (int i = 0; i < AttackingUnit.Stats.Strength; i++)
            {
                Console.Write("-");
                if (i == AttackingUnit.Stats.Precision)
                {
                    Console.Write("|");
                }
                if (i == AttackingUnit.Stats.Accuracy)
                {
                    Console.Write("|");
                }
                if (i == attack)
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return attack; //
        }

        public static int DefenseCalculator(Unit DefendingUnit)
        {
            Console.WriteLine("Defending Unit is: ");
            Random rand = new Random();
            int Defense = rand.Next(DefendingUnit.Stats.Precision, DefendingUnit.Stats.Accuracy);
            Display.FightDisplay(DefendingUnit);
            Console.Write("\t\t\tDefense: " + Defense);
            for (int i = 0; i < DefendingUnit.Stats.Strength; i++)
            {
                Console.Write("-");
                if (i == DefendingUnit.Stats.Precision)
                {
                    Console.Write("|");
                }
                if (i == DefendingUnit.Stats.Accuracy)
                {
                    Console.Write("|");
                }
                if (i == Defense)
                {
                    Console.Write("T");
                }
            }
            Console.WriteLine();
            return Defense;
        }

        public static int HitpointCalculator(int attack, int defense)
        {

            // 5 2
            // 3
            if (attack > defense)
            {
                return attack - defense;
                //3 3
            }
            if (attack <= defense)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
