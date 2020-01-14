using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MP6Editor
{
    public struct Circle
    {
        public Circle(int x, int y, int radius)
            : this()
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public int Radius { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool ContainsPoint(Point point)
        {
            var vector2 = new Vector2(point.X - X, point.Y - Y);
            return vector2.Length() <= Radius;
        }
    }
}
