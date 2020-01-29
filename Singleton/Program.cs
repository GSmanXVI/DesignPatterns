using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Singleton
    {
        static private Singleton instance = null;
        static public Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        public List<int> Data { get; set; }

        private Singleton()
        {
            Data = new List<int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.Data.Add(1);

            Singleton obj1 = Singleton.Instance;
            Singleton obj2 = Singleton.Instance;
            Singleton obj3 = Singleton.Instance;

            obj1.Data.Add(2);
            obj2.Data.Add(3);
            obj3.Data.Add(4);

            foreach (var item in Singleton.Instance.Data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
