﻿using DifferentialEquationNumerical.Models;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationNumerical
{
    public static class SimpleEquation
    {

        public static void CalculateSimpleEquation(string expression,ref double[] x, ref double[] y, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;
                x[i] = xi;
                y[i] = calculateExpression(expression, xi);
            }
        }

        public static double[,] CalculateSimpleEquation_ArrayReturn(string expression, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            var resultMass = new double[2, stepAmounts];

            for(int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;
                resultMass[0, i] = xi;
                resultMass[1, i] = calculateExpression(expression, xi);
            }

            return resultMass;
        }

        public static IPoint[] CalculateSimpleEquation(string expression, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {

            var resultMass = new Point[stepAmounts];

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;

                var yi = calculateExpression(expression, xi);

                resultMass[i] = new Point(xi, yi);
               
            }

            return resultMass;
        }


        public static IEnumerable<IPoint> CalculateSimpleEquation_EnumerableReturn(string expression, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            var resultMass = new System.Collections.ObjectModel.ObservableCollection<IPoint>();

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;

                var yi = calculateExpression(expression, xi);

                resultMass.Add(new Point(xi, yi));

            }

            return resultMass;
        }



        public static async Task<double[,]> CalculateSimpleEquationAsync_ArrayReturn(string expression, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateSimpleEquation_ArrayReturn(expression, x0, step, stepAmounts, calculateExpression));
        }

        public static async Task<IPoint[]> CalculateSimpleEquationAsync(string expression, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateSimpleEquation(expression, x0, step, stepAmounts, calculateExpression));
        }


     

    }
}
