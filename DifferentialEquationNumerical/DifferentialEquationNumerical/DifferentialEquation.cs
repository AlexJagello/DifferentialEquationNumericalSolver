using DifferentialEquationNumerical.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DifferentialEquationNumerical
{
    public static class DifferentialEquation
    {

        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_Eiler(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {

            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                resultMass.Add(new Point(xi, 
                    resultMass[i - 1].Y + h * calculateExpression(expression, xi - h, resultMass[i - 1].Y)));
            }

            return resultMass;
        }



        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_ImpEiler(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                resultMass.Add(new Point(xi, resultMass[i - 1].Y + h *
                    calculateExpression(expression, resultMass[i - 1].X + (h / 2) *
                    calculateExpression(expression, resultMass[i - 1].X, resultMass[i - 1].Y),
                    resultMass[i - 1].Y + (h / 2))));
            }

            return resultMass;
        }

        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double k1, k2, k3, k4, xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                k1 = calculateExpression(expression, resultMass[i - 1].X, resultMass[i - 1].Y);
                k2 = calculateExpression(expression, resultMass[i - 1].X + h * k1 / 2, resultMass[i - 1].Y + h / 2);
                k3 = calculateExpression(expression, resultMass[i - 1].X + h * 0.5 * k2, resultMass[i - 1].Y + 0.5 * h);
                k4 = calculateExpression(expression, resultMass[i - 1].X + h * k3, resultMass[i - 1].Y + h);
                resultMass.Add(new Point( xi, resultMass[i - 1].Y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4)));
            }

            return resultMass;
        }



        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_Eiler(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {

            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                resultMass.Add(new Point(xi, resultMass[i - 1].Y + h *
                    calculateExpression(xi - h, resultMass[i - 1].Y)));
            }

            return resultMass;
        }

        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_ImpEiler(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                resultMass.Add(new Point(xi, resultMass[i - 1].Y + h *
                    calculateExpression(resultMass[i - 1].X + (h / 2) *
                    calculateExpression(resultMass[i - 1].X, resultMass[i - 1].Y),
                    resultMass[i - 1].Y + (h / 2))));
            }

            return resultMass;
        }

        public static ObservableCollection<Point> CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>
            {
                new Point(x0, y0)
            };

            double k1, k2, k3, k4, xi;

            for (int i = 1; i < stepAmounts; i++)
            {
                xi = x0 + i * h;
                k1 = calculateExpression(resultMass[i - 1].X, resultMass[i - 1].Y);
                k2 = calculateExpression(resultMass[i - 1].X + h * k1 / 2, resultMass[i - 1].Y + h / 2);
                k3 = calculateExpression(resultMass[i - 1].X + h * 0.5 * k2, resultMass[i - 1].Y + 0.5 * h);
                k4 = calculateExpression(resultMass[i - 1].X + h * k3, resultMass[i - 1].Y + h);
                resultMass.Add(new Point(xi, resultMass[i - 1].Y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4)));
            }


            return resultMass;
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_Eiler_Async(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_Eiler(expression, x0, y0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_ImpEiler_Async(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_ImpEiler(expression, x0, y0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_RyngeKytte_Async(string expression, double x0, double y0, double h, int stepAmounts, Func<string, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(expression, x0, y0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_Eiler_Async(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_Eiler(x0, y0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_ImpEiler_Async(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_ImpEiler(x0, y0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_EnumerableReturn_RyngeKytte_Async(double x0, double y0, double h, int stepAmounts, Func<double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(x0, y0, h, stepAmounts, calculateExpression));
        }
    }
}
