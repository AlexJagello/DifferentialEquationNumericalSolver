using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEquationNumerical.Models
{
    public struct Point3D : IPoint3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public override string ToString()
        {
            return $"X: {Math.Round(X, 3)}, Y: {Math.Round(Y, 3)}, Z: {Math.Round(Z, 3)};";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is Point3D point)
                if (point.X == X && point.Y == Y && point.Z == Z) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y ^ (int)Z;
        }
    }
}
