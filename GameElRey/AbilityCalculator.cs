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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("New attack ability calculator");
            Unit attacker = FightingUnits.FightUnitAttacker;
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
                Console.WriteLine("Attack Ability has failed to execute.");
                AbilityFailed(attacker);
            }
            if (result == attacker.Stats.Accuracy)
            {
                Console.WriteLine("Perfect Attack bonus XP gained "); // statistic has a bonus function
                Console.WriteLine("Awarded two turns in a row"); // 
            }
            if (result > attacker.Stats.Accuracy)
            {

                Console.WriteLine("result: " + result + " > accuracy " + attacker.Stats.Accuracy);
                Console.WriteLine("Attack Ability will now execute");
                AttackAbilityExecution(FightingUnits, AbilityLibrary.GetAttackAbility(attacker));
            }
        }
        public static void DefenseAbilityCalculator(Fight FightingUnits)
        {
            Console.WriteLine();
            Console.WriteLine();
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
                Console.WriteLine("Defensive Ability will now execute");
                DefenseAbilityExecution(FightingUnits, AbilityLibrary.GetDefenseAbility(defender));
            }
        }

        public static Fight AttackAbilityExecution(Fight FightingUnits, string AbilityName)
        {
            Unit attacker = FightingUnits.FightUnitAttacker;
            Unit defender = FightingUnits.FightUnitDefender;

            if (AbilityName == "IMPALE")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t" + defender.UnitName + " has been IMPALED. ");
                //has lost this much health
                int HPlost = defender.Stats.Hp.CurrentHitpoints;
                Console.WriteLine("\t" +"Has Lost " + HPlost + " health.");
                defender.Stats.Hp.CurrentHitpoints = 0;
                Console.WriteLine("\tLeaving IMPALE mechanics" );
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                return FightingUnits;
            }
            if (AbilityName == "POWER STRIKE")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t" + attacker.UnitName + " has executed a POWER STRIKE on" + defender.UnitName);
                //has lost this much health
                //multiply attack by 2
                int PowerStrike = FightingUnits.FightUnitDamageDone * 2;
                int HPlost = defender.Stats.Hp.CurrentHitpoints - PowerStrike;
                Console.WriteLine("\t" + "Has Lost " + HPlost + " health.");
                Console.WriteLine("\t" + attacker.UnitName + " POWER STRIKE damage:  " + PowerStrike);
                Console.WriteLine("\tLeaving POWERSTRIKE mechanics");
                FightingUnits.FightUnitDamageDone = PowerStrike;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                return FightingUnits;
            }
            if (AbilityName == "SMITE")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t" + attacker.UnitName + " has executed SMITE on " + defender.UnitName);
                Console.WriteLine("\tIgnoring Defenders defense.");
                //has lost this much health
                //multiply attack by 2
                int smite = Fight.AttackCalculator(attacker);// IGNORES DEFENSE

                int HPlost = defender.Stats.Hp.CurrentHitpoints - smite;
                Console.WriteLine("\t" + "Has Lost " + HPlost + " health.");
                Console.WriteLine("\t" + attacker.UnitName + " smite damage:  " + smite);
                Console.WriteLine("\tLeaving SMITE mechanics");
                FightingUnits.FightUnitDamageDone = smite;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                return FightingUnits;
            }
            if (AbilityName == "AURA OF DESTRUCTION")
            {
                Random RandNumber = new Random();

                Unit AuraOfDestructionUnit = attacker;
                int BeforeAuraDamageDone = FightingUnits.FightUnitDamageDone;
                int AfterAuraDamageDone;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t" + attacker.UnitName + " has executed AURA OF DESTRUCTION " + defender.UnitName);
                Console.WriteLine("\tStats have increased until effect has worn off.");
                //has lost this much health
                //multiply attack by 2
                // MULTIPLY ATTACKING STATS BY 2 // FOR SEVERAL TURNS // SET CONDITION OF UNIT

                AuraOfDestructionUnit.Stats.Strength = AuraOfDestructionUnit.Stats.Strength + RandNumber.Next(3, 5);
                AuraOfDestructionUnit.Stats.Precision= AuraOfDestructionUnit.Stats.Precision + RandNumber.Next(3, 5);
                AuraOfDestructionUnit.Stats.Accuracy = AuraOfDestructionUnit.Stats.Accuracy + RandNumber.Next(3, 5);
                AuraOfDestructionUnit.Stats.Agility = AuraOfDestructionUnit.Stats.Agility + RandNumber.Next(3, 5);
                Console.WriteLine("\tSTR: " + AuraOfDestructionUnit.Stats.Strength + 
                    ", PRC: "+ AuraOfDestructionUnit.Stats.Precision + 
                    ", ACC: "+ AuraOfDestructionUnit.Stats.Accuracy + 
                    ", AGI: "+ AuraOfDestructionUnit.Stats.Agility);
                Console.WriteLine("\tDamage Done before AURA OF DESTRUCTION: " + BeforeAuraDamageDone);
                AfterAuraDamageDone = Fight.HitpointCalculator(Fight.AttackCalculator(AuraOfDestructionUnit), Fight.DefenseCalculator(defender));
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\tDamage Done after AURA OF DESTRUCTION: " + AfterAuraDamageDone);

                int HPlost = defender.Stats.Hp.CurrentHitpoints - AfterAuraDamageDone;
                Console.WriteLine("\t" + "Has Lost " + HPlost + " health.");
                Console.WriteLine("\tLeaving Aura Of Destruction mechanics");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                AuraOfDestructionUnit = null;
                FightingUnits.FightUnitAttacker = attacker;// reset base stats
                

                return FightingUnits;
            }
            else {
                return null;
            }
        }

        public static Fight DefenseAbilityExecution(Fight FightingUnits, string AbilityName)
        {
            Unit attacker = FightingUnits.FightUnitAttacker;
            Unit defender = FightingUnits.FightUnitDefender;

            if (AbilityName == "DODGE")
            {
                Display.UnitNameDisplay(defender);
                Console.WriteLine("\tHas dodged.");
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
                // hasent moved position
            }
            if (AbilityName == "EVADE")
            {
                Display.UnitNameDisplay(defender);
                Console.WriteLine("\tHas evaded.");
                //formation 1-2
                // front lines
                // formation 3
                // have you moved formation?
                // has moved in another formation
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "BLOCK")
            {
                Display.UnitNameDisplay(defender);
                Console.WriteLine("\tHas BLOCKED.");
                // based off shield and armor base stats
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "ABILITY PREVENTION")
            {
                Display.UnitNameDisplay(defender);
                Console.WriteLine("\tused ABILITY PREVENTION: ");// display
                Console.WriteLine("\tHas prevented any abilities for one turn."); // disp
                                                                             // opponent will not be able to execute abilities
                FightingUnits.FightUnitDamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "HEAL")
            {
                Console.WriteLine();
                Console.WriteLine("\tHealing...");
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
                        Console.WriteLine("\tOverhealed");
                        defender.Stats.Hp.CurrentHitpoints = defender.Stats.Hp.MaxHitpoints;
                    }
                    else
                    {
                        Display.UnitNameDisplay(defender);
                        Console.WriteLine("\tHas restored 10 life.");
                        Console.WriteLine("\tHP: " + defender.Stats.Hp.CurrentHitpoints + "/" + defender.Stats.Hp.MaxHitpoints);
                        return FightingUnits;
                    }
                    return FightingUnits;
                }
                else
                {
                    Console.WriteLine("\tFull HP");
                    Console.WriteLine("\tHP: " + defender.Stats.Hp.CurrentHitpoints + "/" + defender.Stats.Hp.MaxHitpoints);// potion is preset based off money 
                    return FightingUnits;
                }
            }
            else
            {
                Console.WriteLine("\t\t\tNo abilities?! what happened.");
                return null;
            }

        }

        public static Unit AbilityFailed(Unit u)
        {
            return u;
        }
    }
}
