using DifferentialEquationNumerical;
using DifferentialEquationNumerical.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Comparers;

namespace TestProject
{
    [TestClass]
    public class UnitTestNumericalSolutionOfSimpleEquation
    {
        IList<Point> expected;

        IPoint[] expectedPoints;

        double[,] expectedArray;

        double[] expectedX;
        double[] expectedY;

        public UnitTestNumericalSolutionOfSimpleEquation()
        {
            expected = GetTestData.GetDataList("Resources/simple.json");

            expectedPoints = new IPoint[expected.Count()];
            expectedArray = new double[2,expected.Count()];

            expectedX = new double[expected.Count()];
            expectedY = new double[expected.Count()];

            for (int i = 0; i < expected.Count(); i++)
            {
                expectedPoints[i] = expected[i];

                expectedX[i] = expectedArray[0, i] = expected[i].X;
                expectedY[i] = expectedArray[1, i] = expected[i].Y;

            }
        }


        [TestMethod]
        public void TestSimpleEquationMethodDynamic_v1()
        {
            var result = SimpleEquation.CalculateSimpleEquation("y=2*x+3", 0, 0.1, 100, PythonCalculationClass.PythonCalculation);

            CollectionAssert.AreEqual(expectedPoints, result);
        }

        [TestMethod]
        public void TestSimpleEquationMethodDynamic_v2()
        {
            var result = SimpleEquation.CalculateSimpleEquation_ArrayReturn("y=2*x+3", 0, 0.1, 100, PythonCalculationClass.PythonCalculation);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestSimpleEquationMethodDynamic_v3()
        {
            var result = SimpleEquation.CalculateSimpleEquation_EnumerableReturn("y=2*x+3", 0, 0.1, 100, PythonCalculationClass.PythonCalculation);

            CollectionAssert.AreEqual((ICollection)expected, (ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestSimpleEquationMethodDynamic_v4()
        {
            double[] x;
            double[] y;
            SimpleEquation.CalculateSimpleEquation("y=2*x+3",out x,out y, 0, 0.1, 100, PythonCalculationClass.PythonCalculation);

            CollectionAssert.AreEqual(expectedX, x);
            CollectionAssert.AreEqual(expectedY, y);
        }




        [TestMethod]
        public void TestSimpleEquationMethod_v1()
        {
            var result = SimpleEquation.CalculateSimpleEquation(0, 0.1, 100, Equation);

            CollectionAssert.AreEqual(expectedPoints, result);
        }

        [TestMethod]
        public void TestSimpleEquationMethod_v2()
        {
            var result = SimpleEquation.CalculateSimpleEquation_ArrayReturn(0, 0.1, 100, Equation);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestSimpleEquationMethod_v3()
        {
            var result = SimpleEquation.CalculateSimpleEquation_EnumerableReturn(0, 0.1, 100, Equation);

            CollectionAssert.AreEqual((ICollection)expected, (ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestSimpleEquationMethod_v4()
        {

            double[] x;
            double[] y;
            SimpleEquation.CalculateSimpleEquation(out x, out y,0 , 0.1, 100, Equation);


            CollectionAssert.AreEqual(expectedX, x);
            CollectionAssert.AreEqual(expectedY, y);
        }


        private double Equation(double x)
        {
            return 2 * x + 3;
        }

    }
}
