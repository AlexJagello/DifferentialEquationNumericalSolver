using DifferentialEquationNumerical.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DifferentialEquationNumerical
{
    public static class SimpleEquation
    {

        public static void CalculateSimpleEquation(string expression,out double[] x, out double[] y, double x0, double step, int stepAmounts, Func<string, double, double> calculateExpression)
        {
            x = new double[stepAmounts];
            y = new double[stepAmounts];

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





        public static void CalculateSimpleEquation(out double[] x, out double[] y, double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {
            x = new double[stepAmounts];
            y = new double[stepAmounts];

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;
                x[i] = xi;
                y[i] = calculateExpression(xi);
            }
        }

        public static double[,] CalculateSimpleEquation_ArrayReturn(double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {
            var resultMass = new double[2, stepAmounts];

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;
                resultMass[0, i] = xi;
                resultMass[1, i] = calculateExpression(xi);
            }

            return resultMass;
        }

        public static IPoint[] CalculateSimpleEquation(double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {

            var resultMass = new Point[stepAmounts];

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;

                var yi = calculateExpression(xi);

                resultMass[i] = new Point(xi, yi);

            }

            return resultMass;
        }

        public static IEnumerable<IPoint> CalculateSimpleEquation_EnumerableReturn(double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {
            var resultMass = new System.Collections.ObjectModel.ObservableCollection<IPoint>();

            for (int i = 0; i < stepAmounts; i++)
            {
                var xi = x0 + i * step;

                var yi = calculateExpression(xi);

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

        public static async Task<double[,]> CalculateSimpleEquationAsync_ArrayReturn(double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateSimpleEquation_ArrayReturn(x0, step, stepAmounts, calculateExpression));
        }

        public static async Task<IPoint[]> CalculateSimpleEquationAsync(double x0, double step, int stepAmounts, Func<double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateSimpleEquation(x0, step, stepAmounts, calculateExpression));
        }
    }
}
