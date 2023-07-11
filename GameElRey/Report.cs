using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey.Resources;

namespace GameElRey
{

    // currently last thing happening
    public class Report
    {

        public Report(Resource ResourceCollection)//workout army later
        {
            ResourceCollectionReport = ResourceCollection;
        }


        public Report(Unit unit) {// loot gathered, amount of kills, amount of hits taken or evaded,
            Unit UnitReport = unit;
        }

        public Unit UnitReport {get;set;}

        public Resource ResourceCollectionReport { get; set; }
    }
}
