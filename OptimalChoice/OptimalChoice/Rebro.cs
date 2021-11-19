using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalChoice_
{
    class Rebro
    {
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public float Weight { get; private set; }

        public Rebro(Point first, Point second, float valueOfWeight)
        {
            FirstPoint = first;
            SecondPoint = second;
            Weight = valueOfWeight;
        }

    }
}
