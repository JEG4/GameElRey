using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class KingdomLibrary
    {

        public List<Ability> AbilityList { get; set; }
        public KingdomLibrary(List<Ability> AbilityList)
        {
            this.AbilityList = AbilityList;
        }


    }
}
