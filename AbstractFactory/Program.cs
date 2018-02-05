using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class UnitCreator
    {
        public IUnitFactory UnitFactory { get; set; }

        public void AddWarrior(List<Unit> units)
        {
            units.Add(UnitFactory.CreateWarrior());
        }

        public void AddRanger(List<Unit> units)
        {
            units.Add(UnitFactory.CreateRanger());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Unit> units = new List<Unit>();

            UnitCreator unitCreator = new UnitCreator();

            unitCreator.UnitFactory = new OrcFactory();

            unitCreator.AddWarrior(units);
            unitCreator.AddWarrior(units);
            unitCreator.AddWarrior(units);

            unitCreator.AddRanger(units);
            unitCreator.AddRanger(units);

            unitCreator.UnitFactory = new HumanFactory();

            unitCreator.AddWarrior(units);
            unitCreator.AddWarrior(units);

            unitCreator.AddRanger(units);
            unitCreator.AddRanger(units);
            unitCreator.AddRanger(units);

            foreach (var item in units)
            {
                Console.WriteLine(item);
            }
        }
    }
}
