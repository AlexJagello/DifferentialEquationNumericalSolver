using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEquationNumerical.Models
{
    public interface IPoint3D : IPoint
    {
        double Z { get; set; }
    }
}
