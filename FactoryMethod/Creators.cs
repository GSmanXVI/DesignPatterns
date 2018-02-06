using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    interface IWizzardCreartor
    {
        Wizzard FactoryMethod();
    }

    class HealerCreator : IWizzardCreartor
    {
        public Wizzard FactoryMethod()
        {
            Wizzard wizzard = new Healer();
            wizzard.Spells.Add(new Heal());
            wizzard.Spells.Add(new Resurrect());
            wizzard.Spells.Add(new Fireball());
            return wizzard;
        }
    }

    class WarlockCreator : IWizzardCreartor
    {
        public Wizzard FactoryMethod()
        {
            Wizzard wizzard = new Warlock();
            wizzard.Spells.Add(new Fireball());
            wizzard.Spells.Add(new Frostbolt());
            wizzard.Spells.Add(new Firestorm());
            wizzard.Spells.Add(new Blizzard());
            return wizzard;
        }
    }
}
