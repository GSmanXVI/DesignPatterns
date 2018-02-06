using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IWizzardCreartor[] creators = new IWizzardCreartor[2];
            creators[0] = new HealerCreator();
            creators[1] = new WarlockCreator();

            foreach (IWizzardCreartor creator in creators)
            {
                Wizzard wizzard = creator.FactoryMethod();
                Console.WriteLine($"Created {wizzard.GetType().Name}");
                wizzard.Info();
            }
        }
    }
}
