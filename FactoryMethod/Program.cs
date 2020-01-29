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
            ////GOOD CODE
            Random rand = new Random();
            List<Wizzard> wizzards = new List<Wizzard>();

            List<IWizzardFactory> wizzardCreartors = new List<IWizzardFactory>();
            wizzardCreartors.Add(new HealerFactory());
            wizzardCreartors.Add(new WarlockFactory());

            for (int i = 0; i < 10; i++)
            {
                int randCreatorIndex = rand.Next(0, wizzardCreartors.Count);
                Wizzard wizzard = wizzardCreartors[randCreatorIndex].Create();
                wizzards.Add(wizzard);
            }

            foreach (var item in wizzards)
            {
                Console.WriteLine(item.GetType().Name);
            }




            //////BAD CODE
            //Random rand = new Random();
            //List<Wizzard> wizzards = new List<Wizzard>();
            //for (int i = 0; i < 10; i++)
            //{
            //    int randNumber = rand.Next(0, 2);
            //    if (randNumber == 0)
            //        wizzards.Add(new Healer());
            //    else if (randNumber == 1)
            //        wizzards.Add(new Warlock());
            //}

            //foreach (var item in wizzards)
            //{
            //    Console.WriteLine(item.GetType().Name);
            //}
        }
    }
}
