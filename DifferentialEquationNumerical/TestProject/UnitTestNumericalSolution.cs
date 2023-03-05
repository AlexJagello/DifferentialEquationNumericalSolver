using DifferentialEquationNumerical;
using DifferentialEquationNumerical.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestProject.Comparers;
using static Community.CsharpSqlite.Sqlite3;

namespace TestProject
{
    [TestClass]
    public class UnitTestNumericalSolution
    {

        [TestMethod]
        public void TestEilerMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetTestData.GetData("Resources/dataeiler.json");

            CollectionAssert.AreEqual(expected,(ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestImpEilerMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetTestData.GetData("Resources/dataimpeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestRyngeKytteMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetTestData.GetData("Resources/dataryngekutty.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PointComparer(0.1));
        }






        [TestMethod]
        public void TestEilerMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetTestData.GetData("Resources/dataeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestImpEilerMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetTestData.GetData("Resources/dataimpeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestRyngeKytteMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetTestData.GetData("Resources/dataryngekutty.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PointComparer(0.1));
        }

        public double ExampleDiffEquation(double x, double y)
        {
            return Math.Round(Math.Pow(x,2) - 2*y, 6);
        }

    
    }
}
