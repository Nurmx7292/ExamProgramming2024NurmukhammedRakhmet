using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IReflectable
    {
        public decimal X { get; protected set; }
        public decimal Y { get; protected set; }

        public Point(decimal x)
        {
            X = x;
            Y = 0;
        }

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public void ReflectX()
        {
            X = -X;
        }

        public void ReflectY()
        {
            Y = -Y;
        }

        public virtual bool IsOnAxis => X == 0 || Y == 0;
    }
}
