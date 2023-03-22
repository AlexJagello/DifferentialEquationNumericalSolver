using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationNumerical.Models
{
    public struct Point : IPoint
    {
       public double X { get; set; }
       public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X: {Math.Round(X, 3)}, Y: {Math.Round(Y, 3)};";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if(obj is Point point)  
                if (point.X == X && point.Y == Y) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y;
        }
    }
}
