using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    interface IWizzardFactory
    {
        Wizzard Create();
    }

    class HealerFactory : IWizzardFactory
    {
        public Wizzard Create()
        {
            Wizzard wizzard = new Healer();
            wizzard.Spells.Add(new Heal());
            wizzard.Spells.Add(new Resurrect());
            wizzard.Spells.Add(new Fireball());
            return wizzard;
        }
    }

    class WarlockFactory : IWizzardFactory
    {
        public Wizzard Create()
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
