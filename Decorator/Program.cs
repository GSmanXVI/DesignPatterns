using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    //Component
    abstract class Weapon
    {
        public virtual int Accuracy { get; set; }
        public virtual int Damage { get; set; }
        public virtual int Capacity { get; set; }

        public void Info()
        {
            Console.WriteLine($"Accuracy: {Accuracy}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Capacity: {Capacity}");
            Console.WriteLine();
        }
    }

    //ConcreteComponent
    class M16 : Weapon
    {
        public M16()
        {
            Accuracy = 5;
            Damage = 5;
            Capacity = 30;
        }
    }

    //Decorator
    abstract class Upgrade : Weapon
    {
        private int accuracy;
        public override int Accuracy
        {
            get => weapon.Accuracy + accuracy;
            set => accuracy = value;
        }

        private int damage;
        public override int Damage
        {
            get => weapon.Damage + damage;
            set => damage = value;
        }

        private int capacity;
        public override int Capacity
        {
            get => weapon.Capacity + capacity;
            set => capacity = value;
        }

        Weapon weapon = null;

        public Weapon SetUpgrade(Weapon weapon)
        {
            this.weapon = weapon;
            return this;
        }

        public Weapon RemoveUpgrade()
        {
            var temp = weapon;
            weapon = null;
            return temp;
        }
    }

    //ConcreteDecorator
    class Scope : Upgrade
    {
        public Scope()
        {
            Accuracy = 15; 
        }
    }

    //ConcreteDecorator
    class Suppressor : Upgrade
    {
        public Suppressor()
        {
            Accuracy = 5;
            Damage = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new M16();
            weapon.Info();

            Upgrade upgrade = new Scope();
            weapon = upgrade.SetUpgrade(weapon);
            weapon.Info();

            upgrade = new Suppressor();
            weapon = upgrade.SetUpgrade(weapon);
            weapon.Info();

            //weapon = (weapon as Upgrade).RemoveUpgrade();
            //weapon.Info();
        }
    }
}
