using DifferentialEquationNumerical.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Comparers
{
    public class PointComparer3D : IComparer
    {
        double eps = 0.1;

        public PointComparer3D(double eps)
        {
            this.eps = eps;
        }

        public int Compare(object? p1, object? p2)
        {
            if (p1 is null || p2 is null) throw new ArgumentException();

            if (p1.GetType() != p2.GetType()) throw new ArgumentException();


            if (p1 is Point3D point1)
                if (p2 is Point3D point2)
                { 
                    var difX = Math.Abs(point1.X - point2.X);
                    var difY = Math.Abs(point1.Y - point2.Y);
                    var difZ = Math.Abs(point1.Z - point2.Z);

                    if (difX > eps || difY > eps || difZ > eps)
                        return -1;
                    return 0;
                }
            throw new ArgumentException();
        }

    }
}
