using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class Weapon
    {
        public int Damage { get; set; }
        public int Defense { get; set; }
    }

    class Sword : Weapon
    {
        public Sword()
        {
            Damage = 10;
            Defense = 2;
        }

        public override string ToString() => "Sword";
    }

    class Shield : Weapon
    {
        public Shield()
        {
            Damage = 1;
            Defense = 10;
        }

        public override string ToString() => "Shield";
    }

    class Bow : Weapon
    {
        public Bow()
        {
            Damage = 8;
            Defense = 0;
        }

        public override string ToString() => "Bow";
    }

    abstract class Armor
    {
        public int Defense { get; set; }
    }

    class LeatherArmor : Armor
    {
        public LeatherArmor()
        {
            Defense = 5;
        }

        public override string ToString() => "Leather";
    }

    class ClothArmor : Armor
    {
        public ClothArmor()
        {
            Defense = 2;
        }

        public override string ToString() => "Cloth";
    }

    class PlateArmor : Armor
    {
        public PlateArmor()
        {
            Defense = 10;
        }

        public override string ToString() => "Plate";
    }
}
