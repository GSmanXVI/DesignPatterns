using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Spell
    {
        public int MPCost { get; set; }
    }

    class Heal : Spell
    {
        public Heal()
        {
            MPCost = 10;
        }

        public override string ToString() => $"Heal - {MPCost}MP";
    }

    class Resurrect : Spell
    {
        public Resurrect()
        {
            MPCost = 50;
        }

        public override string ToString() => $"Resurrect - {MPCost}MP";
    }

    class Fireball : Spell
    {
        public Fireball()
        {
            MPCost = 5;
        }

        public override string ToString() => $"Fireball - {MPCost}MP";
    }

    class Frostbolt : Spell
    {
        public Frostbolt()
        {
            MPCost = 8;
        }

        public override string ToString() => $"Frostbolt - {MPCost}MP";
    }

    class Firestorm : Spell
    {
        public Firestorm()
        {
            MPCost = 50;
        }

        public override string ToString() => $"Firestorm - {MPCost}MP";
    }

    class Blizzard : Spell
    {
        public Blizzard()
        {
            MPCost = 80;
        }

        public override string ToString() => $"Blizzard - {MPCost}MP";
    }
}
