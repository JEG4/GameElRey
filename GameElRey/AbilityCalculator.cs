using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey;
using TacticsElRey.Battle;

namespace TacticsElRey
{
    public class AbilityCalculator
    {
        // ability calculator and execution was thinking of naming it controller but unsure

        public static void AttackAbilityCalculator(Fight FightingUnits)
        {
            Console.WriteLine("New attack ability calculator");
            Unit attacker = FightingUnits.BattleUnitAttacker;
            // defensive needs as in heals, need more strength or accuracy
            // if you precision abilities // precision aura(has the party implication.
            // ability requirement to execute
            // dexterity is like a resource
            //  15-5 = 10
            int AbsoluteValue = (attacker.Stats.Accuracy - attacker.Stats.Precision);
            // 10/2 + 5 = 
            int middle = attacker.Stats.Precision + (AbsoluteValue / 2);

            int UpperLimit = middle + attacker.Stats.Dexterity;
            Random rand = new();
            int result = rand.Next(middle, UpperLimit);
            if (result <= attacker.Stats.Accuracy)
            {   //            acc      dex
                //  |---------|---.----|
                //  |---------|--
                Console.WriteLine("result: " + result + "  <= accuracy: " + attacker.Stats.Accuracy);
                Console.Write("Attack Ability has failed to execute.");
                AbilityFailed(attacker);
            }
            if (result == attacker.Stats.Accuracy)
            {
                Console.WriteLine("Perfect Attack bonus XP gained "); // statistic has a bonus function
                Console.Write("Awarded two turns in a row"); // 
            }
            if (result > attacker.Stats.Accuracy)
            {

                Console.WriteLine("result: " + result + " > accuracy " + attacker.Stats.Accuracy);
                Console.Write("Attack Ability will now execute");
                AttackAbilityExecution(FightingUnits, AbilityLibrary.GetAttackAbility(attacker));
            }
        }
        public static void DefenseAbilityCalculator(Fight FightingUnits)
        {

            Console.WriteLine("New defense ability calculator");
            Unit defender = FightingUnits.FightUnitDefender;
            // defensive needs as in heals, need more strength or accuracy
            // if you precision abilities // precision aura(has the party implication.
            // ability requirement to execute
            // dexterity is like a resource
            //  15-5 = 10
            int AbsoluteValue = (defender.Stats.Accuracy - defender.Stats.Precision);
            // 10/2 + 5 = 
            int middle = defender.Stats.Precision + (AbsoluteValue / 2);

            int UpperLimit = middle + defender.Stats.Dexterity;
            Random rand = new();
            int result = rand.Next(middle, UpperLimit);
            if (result <= defender.Stats.Accuracy)
            {   //            acc      dex
                //  |---------|---.----|
                //  |---------|--
                Console.WriteLine("result: " + result + "  <= accuracy: " + defender.Stats.Accuracy);
                Console.Write("Defensive Ability has failed to execute.");
                AbilityFailed(defender);
            }
            if (result == defender.Stats.Accuracy)
            {
                Console.WriteLine("Perfect defense bonus XP gained "); // statistic has a bonus function
                Console.Write("Awarded two turns in a row"); // 
            }
            if (result > defender.Stats.Accuracy)
            {

                Console.WriteLine("result: " + result + " > accuracy " + defender.Stats.Accuracy);
                Console.Write("Defensive Ability will now execute");
                DefenseAbilityExecution(FightingUnits, AbilityLibrary.GetDefenseAbility(defender));
            }
        }

        public static Fight AttackAbilityExecution(Fight FightingUnits, string AbilityName)
        {
            Console.WriteLine("New Attack ability function!");
            return FightingUnits;
        }

        public static Fight DefenseAbilityExecution(Fight FightingUnits, string AbilityName)
        {
            Unit attacker = FightingUnits.BattleUnitAttacker;
            Unit defender = FightingUnits.BattleUnitDefender;

            if (AbilityName == "DODGE")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" Has dodged.");
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
                // hasent moved position
            }
            if (AbilityName == "EVADE")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" Has evaded.");
                //formation 1-2
                // front lines
                // formation 3
                // have you moved formation?
                // has moved in another formation
                Console.Write(" Has dodged.");
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "BLOCK")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" Has BLOCKED.");
                // based off shield and armor base stats
                Console.Write(" Has dodged.");
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "ABILITY PREVENTION")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" used ABILITY PREVENTION: ");// display
                Console.Write(" Has prevented any abilities for one turn."); // disp
                                                                             // opponent will not be able to execute abilities
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "HEAL")
            {
                Console.WriteLine();
                Console.WriteLine("Healing...");
                Display.UnitNameDisplay(defender);
                int Health = defender.Stats.Hp.CurrentHitpoints;
                // if hp is under 10-30% attempts heals perhaps in defense ability calculator
                //
                if (Health < defender.Stats.Hp.MaxHitpoints)
                {
                    defender.Stats.Hp.CurrentHitpoints = defender.Stats.Hp.CurrentHitpoints + 10;
                    if (defender.Stats.Hp.CurrentHitpoints > defender.Stats.Hp.MaxHitpoints)
                    {
                        Display.UnitNameDisplay(defender);
                        Console.WriteLine("Overhealed");
                        defender.Stats.Hp.CurrentHitpoints = defender.Stats.Hp.MaxHitpoints;
                    }
                    else
                    {
                        Display.UnitNameDisplay(defender);
                        Console.WriteLine(" Has restored 10 life.");
                        Console.WriteLine("HP: " + defender.Stats.Hp.CurrentHitpoints + "/" + defender.Stats.Hp.MaxHitpoints);
                        return FightingUnits;
                    }
                    return FightingUnits;
                }
                else
                {
                    Console.WriteLine("Full HP");
                    Console.WriteLine("HP: " + defender.Stats.Hp.CurrentHitpoints + "/" + defender.Stats.Hp.MaxHitpoints);// potion is preset based off money 
                    return FightingUnits;
                }
            }
            else
            {
                Console.WriteLine("No abilities?! what happened.");
                return null;
            }

        }

        public static Unit AbilityFailed(Unit u)
        {
            return u;
        }
    }
}
