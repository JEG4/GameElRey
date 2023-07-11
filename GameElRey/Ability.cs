namespace GameElRey
{
    public class Ability
    {
        public string AbilityName { get; set; }
        // learns which ability is best in each situation
        // MLM
        // determine which ability goes first 
        // attack defend is turn based
        // speed determines which ability goes first
        //[    a1   ][ a2 ][ a3 ][ a4 ][ a5 ][ a6 ][ a7 ][ a8 ]
        public Ability(string name,Level level)// ability has statistics
        {
            AbilityName = name;
        }

        public static Battle DefenseAbility(Battle FightingUnits, string AbilityName)
        {
            Unit attacker = FightingUnits.BattleUnitAttacker;
            Unit defender = FightingUnits.BattleUnitDefender;

            if (AbilityName == "DODGE")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" Has dodged.");
                FightingUnits.DamageDone = 0;
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
                FightingUnits.DamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "BLOCK")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" Has BLOCKED.");
                // based off shield and armor base stats
                Console.Write(" Has dodged.");
                FightingUnits.DamageDone = 0;
                return FightingUnits;
            }
            if (AbilityName == "ABILITY PREVENTION")
            {
                Display.UnitNameDisplay(defender);
                Console.Write(" used ABILITY PREVENTION: ");// display
                Console.Write(" Has prevented any abilities for one turn."); // disp
                                                                             // opponent will not be able to execute abilities
                FightingUnits.DamageDone = 0;
                return FightingUnits;
            } if(AbilityName == "HEAL")
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
            else {
                Console.WriteLine("No abilities?! what happened."); 
                return null; 
            }

        }

        public static Battle AttackAbility(Battle FightingUnits, string AbilityName)
        {
            Console.WriteLine("New Attack ability function!");
            return FightingUnits;
        }

        public static void DefenseAbilityCalculator(Battle FightingUnits)
        {

            Console.WriteLine("New defense ability calculator");
            Unit defender = FightingUnits.BattleUnitDefender;
            // defensive needs as in heals, need more strength or accuracy
            // if you precision abilities // precision aura(has the party implication.
            // ability requirement to execute
            // dexterity is like a resource
            //  15-5 = 10
            int AbsoluteValue = (defender.Stats.Accuracy - defender.Stats.Precision);
            // 10/2 + 5 = 
            int middle = defender.Stats.Precision + (AbsoluteValue/2);

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
            } if(result== defender.Stats.Accuracy)
            {
                Console.WriteLine("Perfect defense bonus XP gained "); // statistic has a bonus function
                Console.Write("Awarded two turns in a row"); // 
            }
            if(result > defender.Stats.Accuracy)
            {

                Console.WriteLine("result: " + result + " > accuracy " + defender.Stats.Accuracy);
                Console.Write("Defensive Ability will now execute");
                DefenseAbility(FightingUnits, GetDefenseAbility(defender)); 
            }
        }

        public static string GetDefenseAbility(Unit u)
        {   
            // 4 abilities
            int i = u.UnitDefenseAbilities.AbilityList.Count;
            Random r = new Random();
            int AbilityIndex = r.Next(0,i);
            Console.WriteLine("Getting defense ability "+ u.UnitDefenseAbilities.AbilityList[AbilityIndex].AbilityName + " at " + AbilityIndex);
            return u.UnitDefenseAbilities.AbilityList[AbilityIndex].AbilityName;
        }

        public static string GetAttackAbility(Unit u)
        {
            // 4 abilities
            int i = u.UnitAttackAbilities.AbilityList.Count;
            Random r = new Random();
            int AbilityIndex = r.Next(0, i);
            Console.WriteLine("Getting attack ability " + u.UnitAttackAbilities.AbilityList[AbilityIndex].AbilityName + " at " + AbilityIndex);
            return u.UnitAttackAbilities.AbilityList[AbilityIndex].AbilityName;
        }

        public static void AttackAbilityCalculator(Battle FightingUnits)
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
                AttackAbility(FightingUnits, GetAttackAbility(attacker));
            }
        }

        public static Battle AbilitySequenceCalculator(Battle FightingUnits)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("New ability sequence calculator.");
            int AttackerSpeed = Battle.SpeedCalculator(FightingUnits.BattleUnitAttacker.Stats);
            int DefenderSpeed = Battle.SpeedCalculator(FightingUnits.BattleUnitDefender.Stats);
            
            if (AttackerSpeed > DefenderSpeed){

                Console.WriteLine("Attacker is faster " + AttackerSpeed);
                AttackAbilityCalculator(FightingUnits); 
                Console.WriteLine("");
                DefenseAbilityCalculator(FightingUnits);
                return FightingUnits;
            }
            if (DefenderSpeed > AttackerSpeed){
                Console.WriteLine("Defender is faster " + DefenderSpeed);
                DefenseAbilityCalculator(FightingUnits);
                Console.WriteLine("");
                AttackAbilityCalculator(FightingUnits);
                return FightingUnits;
            }if(DefenderSpeed == AttackerSpeed) {

                Console.WriteLine("Same speed recalculating.");
                AbilitySequenceCalculator(FightingUnits);
                return FightingUnits;
            }
            else {
                Console.WriteLine("Something weird happened");
                return null;
            }
        }

        public static KingdomLibrary GenerateDefenseAbility(){
            KingdomLibrary GeneratedAbilities = new KingdomLibrary(new List<Ability>());
            
            GeneratedAbilities.AbilityList.Add(new Ability("DODGE", new Level(1, new Experience(0,10))));
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

        public static KingdomLibrary GenerateAttackAbility()
        {
            KingdomLibrary GeneratedAbilities = new KingdomLibrary(new List<Ability>());

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

        public static Unit AbilityFailed(Unit u)
        {
            return u;
        }
    }

    // succeffuly launch attack ability
    // attack turn
        // attack ability
    // defense turn
        // defense ability

}