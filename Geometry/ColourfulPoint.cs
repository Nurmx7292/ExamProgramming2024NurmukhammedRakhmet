using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class ColourfulPoint : Point
    {
        public PointColour Colour { get; private set; }

        public ColourfulPoint(decimal x, decimal y, PointColour colour) : base(x, y)
        {
            Colour = colour;
        }

        public void ChangeColour(PointColour newColour)
        {
            Colour = newColour;
        }

        public void NextColour()
        {
            Colour = (PointColour)(((int)Colour + 1) % Enum.GetValues(typeof(PointColour)).Length);
        }

        public void Normalize()
        {
            decimal distance = (decimal)Math.Sqrt((double)(X * X + Y * Y));
            if (distance != 0)
            {
                X /= distance;
                Y /= distance;
            }
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public void Add(Point other)
        {
            X += other.X;
            Y += other.Y;
        }

        public static Point Add(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public override bool IsOnAxis => base.IsOnAxis && Colour == PointColour.Blue;
    }
}
