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

        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi, yi;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi = resultMass[i - 1].X + h * calculateExpression(expression_dx_by_dz, resultMass[i - 1].X, resultMass[i - 1].Y, zi_1);
                yi = resultMass[i - 1].Y + h * calculateExpression(expression_dy_by_dz, resultMass[i - 1].X, resultMass[i - 1].Y, zi_1);
                resultMass.Add(new Point3D(xi, yi, zi_1 + h)); 
            }

            return resultMass;

        }




        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi_1, yi_1, xi, yi;

            double k1, m1, k2, m2;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * calculateExpression(expression_dx_by_dz, xi_1, yi_1, zi_1);
                m1 = h * calculateExpression(expression_dy_by_dz, xi_1, yi_1, zi_1);

                k2 = h * calculateExpression(expression_dx_by_dz, xi_1 + k1, yi_1 + m1, zi_1 + h);
                m2 = h * calculateExpression(expression_dy_by_dz, xi_1 + k1, yi_1 + m1, zi_1 + h);

                xi = xi_1 + (k1 + k2) / 2.0;
                yi = yi_1 + (m2 + m1) / 2.0;

                resultMass.Add(new Point3D(xi, yi, zi_1 + h));
            }

            return resultMass;
        }

        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi_1, yi_1, xi, yi;

            double k1, k2, k3, k4, m1, m2, m3, m4;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * calculateExpression(expression_dx_by_dz, xi_1, yi_1, zi_1);
                m1 = h * calculateExpression(expression_dy_by_dz, xi_1, yi_1, zi_1);

                k2 = h * calculateExpression(expression_dx_by_dz, xi_1 + k1 / 2.0, yi_1 + m1 / 2.0, zi_1 + h / 2.0);
                m2 = h * calculateExpression(expression_dy_by_dz, xi_1 + k1 / 2.0, yi_1 + m1 / 2.0, zi_1 + h / 2.0);

                k3 = h * calculateExpression(expression_dx_by_dz, xi_1 + k2 / 2.0, yi_1 + m2 / 2.0, zi_1 + h / 2.0);
                m3 = h * calculateExpression(expression_dy_by_dz, xi_1 + k2 / 2.0, yi_1 + m2 / 2.0, zi_1 + h / 2.0);

                k4 = h * calculateExpression(expression_dx_by_dz, xi_1 + k3, yi_1 + m3, zi_1 + h);
                m4 = h * calculateExpression(expression_dy_by_dz, xi_1 + k3, yi_1 + m3, zi_1 + h);

                xi = xi_1 + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0;
                yi = yi_1 + (m1 + 2.0 * m2 + 2.0 * m3 + m4) / 6.0;

                resultMass.Add(new Point3D(xi, yi, zi_1 + h));
            }

            return resultMass;
        }






        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {

            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi, yi;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi = resultMass[i - 1].X + h * expression_dx_by_dz(resultMass[i - 1].X, resultMass[i - 1].Y, zi_1);
                yi = resultMass[i - 1].Y + h * expression_dy_by_dz(resultMass[i - 1].X, resultMass[i - 1].Y, zi_1);
                resultMass.Add(new Point3D(xi, yi, zi_1 + h));
            }

            return resultMass;

        }




        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {
            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi_1, yi_1, xi, yi;

            double k1, m1, k2, m2;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * expression_dx_by_dz(xi_1, yi_1, zi_1);
                m1 = h * expression_dy_by_dz(xi_1, yi_1, zi_1);

                k2 = h * expression_dx_by_dz(xi_1 + k1, yi_1 + m1, zi_1 + h);
                m2 = h * expression_dy_by_dz(xi_1 + k1, yi_1 + m1, zi_1 + h);

                xi = xi_1 + (k1 + k2) / 2.0;
                yi = yi_1 + (m2 + m1) / 2.0;

                resultMass.Add(new Point3D(xi, yi, zi_1 + h));
            }

            return resultMass;
        }

        public static ObservableCollection<Point3D> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {
            var resultMass = new ObservableCollection<Point3D>()
            {
                new Point3D(x0, y0, z0),
            };

            double zi_1, xi_1, yi_1, xi, yi;

            double k1, k2, k3, k4, m1, m2, m3, m4;

            for (int i = 1; i < stepAmounts; i++)
            {
                zi_1 = z0 + (i - 1) * h;
                xi_1 = resultMass[i - 1].X;
                yi_1 = resultMass[i - 1].Y;

                k1 = h * expression_dx_by_dz(xi_1, yi_1, zi_1);
                m1 = h * expression_dy_by_dz(xi_1, yi_1, zi_1);

                k2 = h * expression_dx_by_dz(xi_1 + k1 / 2.0, yi_1 + m1 / 2.0, zi_1 + h / 2.0);
                m2 = h * expression_dy_by_dz(xi_1 + k1 / 2.0, yi_1 + m1 / 2.0, zi_1 + h / 2.0);

                k3 = h * expression_dx_by_dz(xi_1 + k2 / 2.0, yi_1 + m2 / 2.0, zi_1 + h / 2.0);
                m3 = h * expression_dy_by_dz(xi_1 + k2 / 2.0, yi_1 + m2 / 2.0, zi_1 + h / 2.0);

                k4 = h * expression_dx_by_dz(xi_1 + k3, yi_1 + m3, zi_1 + h);
                m4 = h * expression_dy_by_dz(xi_1 + k3, yi_1 + m3, zi_1 + h);

                xi = xi_1 + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0;
                yi = yi_1 + (m1 + 2.0 * m2 + 2.0 * m3 + m4) / 6.0;

                resultMass.Add(new Point3D(xi, yi, zi_1 + h));
            }

            return resultMass;
        }





        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler_Async(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(expression_dx_by_dz, expression_dy_by_dz, x0, y0, z0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler_Async(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(expression_dx_by_dz, expression_dy_by_dz, x0, y0, z0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte_Async(string expression_dx_by_dz, string expression_dy_by_dz, double x0, double y0, double z0, double h, int stepAmounts, Func<string, double, double, double, double> calculateExpression)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(expression_dx_by_dz, expression_dy_by_dz, x0, y0, z0, h, stepAmounts, calculateExpression));
        }

        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler_Async(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler(x0, y0, z0, h, stepAmounts, expression_dx_by_dz, expression_dy_by_dz));
        }

        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler_Async(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler(x0, y0, z0, h, stepAmounts, expression_dx_by_dz, expression_dy_by_dz));
        }

        public static async Task<ObservableCollection<Point3D>> CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte_Async(double x0, double y0, double z0, double h, int stepAmounts, Func<double, double, double, double> expression_dx_by_dz, Func<double, double, double, double> expression_dy_by_dz)
        {
            return await Task.Run(() => CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte(x0, y0, z0, h, stepAmounts, expression_dx_by_dz, expression_dy_by_dz));
        }
    }
}
