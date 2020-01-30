using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Circle
    {
        public void PaintCircle(int x, int y, int radius)
        {
            Console.WriteLine("Circle:");
            Console.WriteLine($"X: {x}; Y: {y}");
            Console.WriteLine($"Radius: {radius}");
        }
    }
}
