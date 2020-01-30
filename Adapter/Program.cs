using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    #region GOOD
    interface IShape
    {
        void Draw(int x1, int y1, int x2, int y2);
    }

    class RectangleAdapter : IShape
    {
        private readonly Rectangle adaptee;

        public RectangleAdapter(Rectangle adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Draw(int x1, int y1, int x2, int y2)
        {
            int width = x2 - x1;
            int height = y2 - y1;
            adaptee.Draw(x1, y1, width, height);
        }
    }

    class LineAdapter : IShape
    {
        private readonly Line adaptee;

        public LineAdapter(Line adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Draw(int x1, int y1, int x2, int y2)
        {
            adaptee.DrawLine(x1, y1, x2, y2);
        }
    }

    class CircleAdapter : IShape
    {
        private readonly Circle adaptee;

        public CircleAdapter(Circle adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Draw(int x1, int y1, int x2, int y2)
        {
            int radius = (x2 - x1) / 2;
            int centerX = x1 + radius;
            int centerY = y1 + radius;
            adaptee.PaintCircle(centerX, centerY, radius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<IShape>
            {
                new RectangleAdapter(new Rectangle()),
                new LineAdapter(new Line()),
                new CircleAdapter(new Circle())
            };

            foreach (var item in shapes)
            {
                item.Draw(5, 5, 15, 15);
            }
        }
    }
    #endregion

    #region BAD
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var shapes = new List<object>
    //        {
    //            new Rectangle(),
    //            new Line(),
    //            new Circle()
    //        };

    //        foreach (var item in shapes)
    //        {
    //            if (item is Rectangle)
    //            {
    //                (item as Rectangle).Draw(5, 5, 10, 10);
    //            }
    //            else if (item is Line)
    //            {
    //                (item as Line).Draw(5, 5, 15, 15);
    //            }
    //            else if (item is Circle)
    //            {
    //                (item as Circle).Draw(10, 10, 5);
    //            }
    //        }
    //    }
    //}
    #endregion
}
