using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface IUnitFactory
    {
        Warrior CreateWarrior();
        Ranger CreateRanger();
    }

    class OrcFactory : IUnitFactory
    {
        public Ranger CreateRanger()
        {
            return new Axethrowher();
        }

        public Warrior CreateWarrior()
        {
            return new Grunt();
        }
    }

    class HumanFactory : IUnitFactory
    {
        public Ranger CreateRanger()
        {
            return new Archer();
        }

        public Warrior CreateWarrior()
        {
            return new Footman();
        }
    }
}
