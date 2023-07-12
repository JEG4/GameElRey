﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey;

namespace TacticsElRey.Battle
{
    public class Battle
    {
        public Unit BattleUnitAttacker { get; set; }
        public Unit BattleUnitDefender { get; set; }

        public Battle(Unit unit1, Unit unit2) // will create a fight class
        {

            BattleUnitAttacker = unit1;
            BattleUnitDefender = unit2;
        }
        

        public static Kingdom BattlePrompt(Kingdom k1)
        {
            Console.WriteLine("Battle Prompt");
            return k1;
        }


        public static Unit FightSequence(Unit unit1, Unit unit2)
        {
            Console.WriteLine();
            Console.WriteLine();
            Battle BattleUnits = new Battle(unit1, unit2);
            Fight FightingUnits = new Fight(BattleUnits.BattleUnitAttacker, BattleUnits.BattleUnitDefender, 0);
            Unit attacker = FightingUnits.FightUnitAttacker;
            Unit defender = FightingUnits.FightUnitDefender;

            if (attacker.Stats.Hp.CurrentHitpoints <= 0)
            {
                Display.FightDisplay(attacker);
                Console.Write(" HAS BEEN ELIMINATED. ");
                return defender;// attacker has died
            }
            if (defender.Stats.Hp.CurrentHitpoints <= 0)
            {
                Display.FightDisplay(defender);
                Console.Write(" HAS BEEN ELIMINATED. ");
                return attacker;// defender has died
            }
            if (defender.Stats.Hp.CurrentHitpoints > 0 && attacker.Stats.Hp.CurrentHitpoints > 0)
            {
                Display.FightDisplay(attacker);
                Display.FightDisplay(defender);
                Fight UpdatedFightingUnits = Fight.AttackTurn(FightingUnits);
                    
                    //.AttackTurn(FightingUnits);
                Display.FightDisplay(UpdatedFightingUnits.FightUnitAttacker, UpdatedFightingUnits.FightUnitDefender);
                Display.FightDisplay(UpdatedFightingUnits.FightUnitDefender);// whats this do?
                UpdatedFightingUnits.FightUnitDefender.Stats.Hp.CurrentHitpoints = UpdatedFightingUnits.FightUnitAttacker.Stats.Hp.CurrentHitpoints - UpdatedFightingUnits.FightUnitDamageDone;
                Display.FightDisplay(UpdatedFightingUnits.FightUnitDamageDone);
                // switch sides
                return FightSequence(UpdatedFightingUnits.FightUnitDefender, UpdatedFightingUnits.FightUnitAttacker);// defender turns into attacker

            }
            else
            {
                Console.WriteLine("Something strange happened");
                return null;
            }

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