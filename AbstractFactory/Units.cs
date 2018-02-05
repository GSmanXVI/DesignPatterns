using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class Unit
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        abstract public void Attack(Unit target);
    }

    abstract class Warrior : Unit
    {
        public override void Attack(Unit target)
        {
            target.HP -= Damage;
            Console.WriteLine("Melee attack");
        }
    }

    abstract class Ranger : Unit
    {
        public override void Attack(Unit target)
        {
            target.HP -= Damage;
            Console.WriteLine("Range attack");
        }
    }

    class Grunt : Warrior
    {
        public override string ToString()
        {
            return "Orc Grunt (Warrior)";
        }
    }

    class Footman : Warrior
    {
        public override string ToString()
        {
            return "Human Footman (Warrior)";
        }
    }

    class Archer : Ranger
    {
        public override string ToString()
        {
            return "Human Archer (Ranger)";
        }
    }

    class Axethrowher : Ranger
    {
        public override string ToString()
        {
            return "Orc Axethrowher (Ranger)";
        }
    }
}
