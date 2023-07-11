using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameElRey
{
    public class Enemy
    {
        public List<Unit> EnemyUnit { get; set; }


        public Enemy(List<Unit> unit)
        {
            EnemyUnit = unit;
        }

        public static List<Unit> AutogenerateEnemies()
        {   
            List<Unit> enemies = new List<Unit>();
            Console.WriteLine("Auto generating enemies");
            for(int i = 0; i < 10; i++)
            {
                AddToEnemy(enemies, Unit.CreateEnemyUnit());
            }
            Console.WriteLine("Auto generated enemies count: " + enemies.Count);
            return enemies;

        }

        public static List<Unit> AddToEnemy(List<Unit> a, Unit u)
        {
            // perhaps redundant once created run
            Console.WriteLine();
            Console.WriteLine("Enemy capacity before " + a.Count);
            Console.WriteLine("Adding Enemy:" + u.UnitType);
            a.Add(u);

            Console.WriteLine("Enemy capacity after " + a.Count);
            return a;
        }

    }
}
