using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace DifferentialEquationNumerical
{
    public static class PythonCalculationClass
    {
        private static readonly ScriptEngine engine;
        private static readonly ScriptScope scope;

        static PythonCalculationClass()
        {
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
        }

        public static double PythonCalculation(string expression, double x)
        {
            scope.SetVariable("x", x);
            engine.Execute("from math import *\n" + expression, scope);
            dynamic res = scope.GetVariable("y");
            return Convert.ToDouble(res);
        }

        public static double PythonCalculation_DifferentialEquation(string expression, double x, double y)
        {
            scope.SetVariable("x", x);
            scope.SetVariable("y", y);
            engine.Execute("from math import *\n" + expression, scope);
            dynamic res = scope.GetVariable("dy");
            return Convert.ToDouble(res);
        }

        public static double PythonCalculation_DifferentialEquation_System2D(string expression, double x, double y, double z)
        {
            scope.SetVariable("x", x);
            scope.SetVariable("y", y);
            scope.SetVariable("z", z);
            engine.Execute("from math import *\n" + expression, scope);
            dynamic res = scope.GetVariable("dy");
            return Convert.ToDouble(res);
        }
    }
}
