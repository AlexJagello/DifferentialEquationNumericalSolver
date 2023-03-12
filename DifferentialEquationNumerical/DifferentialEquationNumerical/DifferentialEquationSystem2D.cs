using DifferentialEquationNumerical.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationNumerical
{
    public static class DifferentialEquationSystem2D
    {

        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {

            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi, yi;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi = resultMass[i - 1].X + h * calculateExpression(expression1, resultMass[i - 1].X, resultMass[i - 1].Y, ti_1);
                yi = resultMass[i - 1].Y + h * calculateExpression(expression2, resultMass[i - 1].X, resultMass[i - 1].Y, ti_1);
                resultMass.Add(new Point(xi, yi)); 
            }

            return resultMass;

        }




        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi_1, yi_1, xi, yi;

            double k1, m1, k2, m2;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * calculateExpression(expression1, xi_1, yi_1, ti_1);
                m1 = h * calculateExpression(expression2, xi_1, yi_1, ti_1);

                k2 = h * calculateExpression(expression1, xi_1 + k1, yi_1 + m1, ti_1 + h);
                m2 = h * calculateExpression(expression2, xi_1 + k1, yi_1 + m1, ti_1 + h);

                xi = xi_1 + (k1 + k2) / 2.0;
                yi = yi_1 + (m2 + m1) / 2.0;

                resultMass.Add(new Point(xi, yi));
            }

            return resultMass;
        }

        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi_1, yi_1, xi, yi;

            double k1, k2, k3, k4, m1, m2, m3, m4;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = calculateExpression(expression1, xi_1, yi_1, ti_1);
                m1 = calculateExpression(expression2, xi_1, yi_1, ti_1);

                k2 = calculateExpression(expression1, xi_1 + k1 / 2, yi_1 + m1 / 2, ti_1 + h / 2);
                m2 = calculateExpression(expression2, xi_1 + k1 / 2, yi_1 + m1 / 2, ti_1 + h / 2);

                k3 = calculateExpression(expression1, xi_1 + k2 / 2, yi_1 + m2 / 2, ti_1 + h / 2);
                m3 = calculateExpression(expression2, xi_1 + k2 / 2, yi_1 + m2 / 2, ti_1 + h / 2);

                k4 = calculateExpression(expression1, xi_1 + k3, yi_1 + m3, ti_1 + h);
                m4 = calculateExpression(expression2, xi_1 + k3, yi_1 + m3, ti_1 + h);

                xi = xi_1 + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                yi = yi_1 + (h / 6) * (m1 + 2 * m2 + 2 * m3 + m4);

                resultMass.Add(new Point(xi, yi));
            }

            return resultMass;
        }






        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {

            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi, yi;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi = resultMass[i - 1].X + h * calculateExpression1(resultMass[i - 1].X, resultMass[i - 1].Y, ti_1);
                yi = resultMass[i - 1].Y + h * calculateExpression2(resultMass[i - 1].X, resultMass[i - 1].Y, ti_1);
                resultMass.Add(new Point(xi, yi));
            }

            return resultMass;

        }




        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {
            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi_1, yi_1, xi, yi;

            double k1, m1, k2, m2;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * calculateExpression1(xi_1, yi_1, ti_1);
                m1 = h * calculateExpression2(xi_1, yi_1, ti_1);

                k2 = h * calculateExpression1(xi_1 + k1, yi_1 + m1, ti_1 + h);
                m2 = h * calculateExpression2(xi_1 + k1, yi_1 + m1, ti_1 + h);

                xi = xi_1 + (k1 + k2) / 2.0;
                yi = yi_1 + (m2 + m1) / 2.0;

                resultMass.Add(new Point(xi, yi));
            }

            return resultMass;
        }

        public static ObservableCollection<Point> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {
            var resultMass = new ObservableCollection<Point>()
            {
                new Point(x0, y0),
            };

            double ti_1, xi_1, yi_1, xi, yi;

            double k1, k2, k3, k4, m1, m2, m3, m4;

            for (int i = 1; i < stepAmounts; i++)
            {
                ti_1 = t0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = calculateExpression1(xi_1, yi_1, ti_1);
                m1 = calculateExpression2(xi_1, yi_1, ti_1);

                k2 = calculateExpression1(xi_1 + k1 / 2, yi_1 + m1 / 2, ti_1 + h / 2);
                m2 = calculateExpression2(xi_1 + k1 / 2, yi_1 + m1 / 2, ti_1 + h / 2);

                k3 = calculateExpression1(xi_1 + k2 / 2, yi_1 + m2 / 2, ti_1 + h / 2);
                m3 = calculateExpression2(xi_1 + k2 / 2, yi_1 + m2 / 2, ti_1 + h / 2);

                k4 = calculateExpression1(xi_1 + k3, yi_1 + m1, ti_1 + h);
                m4 = calculateExpression2(xi_1 + k3, yi_1 + m2, ti_1 + h);

                xi = xi_1 + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                yi = yi_1 + (h / 6) * (m1 + 2 * m2 + 2 * m3 + m4);

                resultMass.Add(new Point(xi, yi));
            }

            return resultMass;
        }





        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler_Async(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(expression1, expression2, x0, y0, t0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler_Async(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(expression1, expression2, x0, y0, t0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte_Async(string expression1, string expression2, double x0, double y0, double t0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(expression1, expression2, x0, y0, t0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler_Async(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(x0, y0, t0, h, stepAmounts, calculateExpression1, calculateExpression2));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler_Async(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(x0, y0, t0, h, stepAmounts, calculateExpression1, calculateExpression2));
        }

        public static async Task<ObservableCollection<Point>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte_Async(double x0, double y0, double t0, double h, int stepAmounts, Func<double, double, double, double> calculateExpression1, Func<double, double, double, double> calculateExpression2)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(x0, y0, t0, h, stepAmounts, calculateExpression1, calculateExpression2));
        }
    }
}
