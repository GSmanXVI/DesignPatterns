using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Rectangle
    {
        public void Draw(int x, int y, int width, int height)
        {
            Console.WriteLine("Rectangle:");
            Console.WriteLine($"X: {x}; Y: {y}");
            Console.WriteLine($"Width: {width}; Height: {height}");
        }
    }
}
