using TacticsElRey.Battle;

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

       


    }

    // succeffuly launch attack ability
    // attack turn
        // attack ability
    // defense turn
        // defense ability

}