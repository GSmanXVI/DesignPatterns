using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Line
    {
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine("Line:");
            Console.WriteLine($"X1: {x1}; Y1: {y1}");
            Console.WriteLine($"X2: {x2}; Y2: {y2}");
        }
    }
}
