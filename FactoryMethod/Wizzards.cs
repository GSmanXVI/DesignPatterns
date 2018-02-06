using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Wizzard
    {
        public int MP { get; set; }
        public List<Spell> Spells { get; set; }

        public Wizzard()
        {
            Spells = new List<Spell>();
        }

        public void Info()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Mana points: {MP}");
            Console.WriteLine("\nSpells list:");
            foreach (var item in Spells)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------\n");
        }
    }

    class Healer : Wizzard
    {
        public Healer()
        {
            MP = 200;
        }
    }

    class Warlock : Wizzard
    {
        public Warlock()
        {
            MP = 250;
        }
    }
}
