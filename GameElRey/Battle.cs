using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Battle
    {
        public Unit BattleUnitAttacker { get; set; }
        public Unit BattleUnitDefender { get; set; }
        public int DamageDone;
        public Battle(Unit unit1, Unit unit2, int Damage) // will create a fight class
        {
            BattleUnitAttacker = unit1;
            BattleUnitDefender = unit2;
            DamageDone = Damage;

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

        public static Kingdom BattlePrompt(Kingdom k1)
        {
            Console.WriteLine("Battle Prompt");
            return k1;
        }

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

        public static int AttackCalculator(Statistic s)
        {
            Random rand = new Random();
            int attack = rand.Next(s.Precision, s.Accuracy);
            Console.WriteLine("Attack: " + attack);
            for (int i = 0; i < s.Strength; i++)
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
                if (i == attack)
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return attack;
        }

        public static int DefenseCalculator(Statistic s)
        {  
            Random rand = new Random();
            int Defense = rand.Next(s.Precision, s.Accuracy);
            Console.WriteLine("Defense: " + Defense);
            for (int i = 0; i < s.Strength; i++)
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
            if(attack > defense)
            {
                return attack - defense;
              //3 3
            }if(attack <= defense)
            {
                return 0;
            } else
            {
                return 0;
            }
        }

        public static Unit FightSequence(Unit unit1, Unit unit2)
        {
            Console.WriteLine();
            Console.WriteLine();
            Battle FightingUnits = new Battle(unit1, unit2,0);
            Unit attacker = FightingUnits.BattleUnitAttacker;
            Unit defender= FightingUnits.BattleUnitDefender;

            if (attacker.Stats.Hp.CurrentHitpoints <= 0)
            {
                Display.FightDisplay(attacker);
                Console.Write(" HAS BEEN ELIMINATED. ");
                return defender;// attacker has died
            } if (defender.Stats.Hp.CurrentHitpoints <= 0)
            {
                Display.FightDisplay(defender);
                Console.Write(" HAS BEEN ELIMINATED. ");
                return attacker;// defender has died
            } 
            if((defender.Stats.Hp.CurrentHitpoints > 0)&&(attacker.Stats.Hp.CurrentHitpoints > 0))
            {
                Display.FightDisplay(attacker);
                Display.FightDisplay(defender);
                Battle UpdatedFightingUnits = AttackTurn(FightingUnits);
                Display.FightDisplay(UpdatedFightingUnits.BattleUnitAttacker, UpdatedFightingUnits.BattleUnitDefender);
                Display.FightDisplay(UpdatedFightingUnits.DamageDone);
                UpdatedFightingUnits.BattleUnitDefender.Stats.Hp.CurrentHitpoints = UpdatedFightingUnits.BattleUnitAttacker.Stats.Hp.CurrentHitpoints - UpdatedFightingUnits.DamageDone;

                // switch sides
                return FightSequence(UpdatedFightingUnits.BattleUnitDefender, UpdatedFightingUnits.BattleUnitAttacker);// defender turns into attacker
                
            } else
            {
                Console.WriteLine("Something strange happened");
                return null;
            }

        }



        public static Battle AttackTurn(Battle FightingUnits)
        {
            Console.WriteLine();
            Console.WriteLine();
            // later: swords is base of attack
            Unit attacker = FightingUnits.BattleUnitAttacker;
            Unit defender = FightingUnits.BattleUnitDefender;

            Console.WriteLine("NEW Attack turn function");
            FightingUnits.DamageDone = HitpointCalculator(AttackCalculator(attacker.Stats),
                DefenseCalculator(defender.Stats));

            Ability.AbilitySequenceCalculator(FightingUnits);

            return FightingUnits;
        }




        public static bool IsUnitDead(Unit u)
        {
            if (u.Stats.Hp.CurrentHitpoints <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
