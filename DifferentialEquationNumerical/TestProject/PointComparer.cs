using DifferentialEquationNumerical.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class PeopleComparer : IComparer
    {
        double eps = 0.1;

        public PeopleComparer(double eps)
        {
            this.eps = eps;
        }

        public int Compare(Object? p1, Object? p2)
        {
            if (p1 is null || p2 is null) throw new ArgumentException();

            if (p1.GetType() != p2.GetType()) throw new ArgumentException();


            if (p1 is Point point1)
                if (p2 is Point point2)
                {

                    var difX = Math.Abs(point1.X - point2.X);
                    var difY = Math.Abs(point1.Y - point2.Y);

                    if (difX > eps || difY > eps)
                        return -1;
                    return 0;
                }
            throw new ArgumentException();
        }

    }
}
