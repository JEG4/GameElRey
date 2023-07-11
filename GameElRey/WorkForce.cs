using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameElRey.Resources;

namespace GameElRey
{
    public class WorkForce
    {
        public WorkForce(List<Worker> Worker)
        {
            this.Worker = Worker;
        }

        public List<Worker> Worker { get; set; }



        
    }

    /*
     * 
     *                 Statistic statistic = new Statistic(level,
                    precision,
                    accuracy,
                    strength,
                    BaseDexterity,
                    BaseIntelligence,
                    formation,
                    mana,
                    hp
                    );*/
}
