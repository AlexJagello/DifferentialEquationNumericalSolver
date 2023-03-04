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
using static Community.CsharpSqlite.Sqlite3;

namespace TestProject
{
    [TestClass]
    public class UnitTestNumericalSolution
    {

        [TestMethod]
        [DeploymentItem(@"Resources/dataeiler.json", "resources")]
        public void TestEilerMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetData("Resources/dataeiler.json");

            CollectionAssert.AreEqual(expected,(ICollection)result, new PeopleComparer(0.1));
        }

        [TestMethod]
        [DeploymentItem(@"Resources/dataimpeiler.json", "resources")]
        public void TestImpEilerMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetData("Resources/dataimpeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PeopleComparer(0.1));
        }

        [TestMethod]
        [DeploymentItem(@"Resources/dataryngekutty.json", "resources")]
        public void TestRyngeKytteMethod_Dynamic()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte("dy=pow(x,2)-2*y", 0, 1, 0.1, 100, PythonCalculationClass.PythonCalculation_DifferentialEquation);
            var expected = GetData("Resources/dataryngekutty.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PeopleComparer(0.1));
        }






        [TestMethod]
        public void TestEilerMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetData("Resources/dataeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PeopleComparer(0.1));
        }

        [TestMethod]
        public void TestImpEilerMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetData("Resources/dataimpeiler.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PeopleComparer(0.1));
        }

        [TestMethod]
        public void TestRyngeKytteMethod()
        {
            var result = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(0, 1, 0.1, 100, ExampleDiffEquation);
            var expected = GetData("Resources/dataryngekutty.json");

            CollectionAssert.AreEqual(expected, (ICollection)result, new PeopleComparer(0.1));
        }

        public double ExampleDiffEquation(double x, double y)
        {
            return Math.Round(Math.Pow(x,2) - 2*y, 6);
        }

        public ICollection GetData(string fileName)
        {
            var list = new List<Point>();

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                list = JsonSerializer.Deserialize<List<Point>>(fs);
            }
            return list;
        }

    }
}
