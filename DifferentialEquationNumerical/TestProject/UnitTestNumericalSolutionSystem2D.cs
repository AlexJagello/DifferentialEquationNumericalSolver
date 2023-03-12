using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DifferentialEquationNumerical;
using DifferentialEquationNumerical.Models;
using TestProject.Comparers;

namespace TestProject
{
    [TestClass]
    public class UnitTestNumericalSolutionSystem2D
    {
        [TestMethod]
        public void TestDifferentialEquationSystem2D_Eiler_Dynamic()
        {
           var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler("dy=-2*x-y+t", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
           var expected = new List<Point>() { 
            
                new Point(0,1),
                new Point(-0.2,1),
                new Point(-0.28,0.96),
                new Point(-0.28,0.904),
                new Point(-0.2288, 0.848),
                new Point(-0.14688,0.80224),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer(0.03));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_ImpEiler_Dynamic()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler("dy=-2*x-y+t", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
            var expected = new List<Point>() {

                new Point(0, 1),
                new Point(-0.18, 1),
                new Point(-0.244, 0.962),
                new Point(-0.2314, 0.9096),
                new Point(-0.17048, 0.85846),
                new Point(-0.08127, 0.818532),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer(0.1));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_RyngeKytte_Dynamic()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte("dy=-2*x-y+t", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
            var expected = new List<Point>() {

                new Point(0,1),
                new Point(-0.1462, 0.983667),
                new Point(-0.20654, 0.947189),
                new Point(-0.20734, 0.904977),
                new Point(-0.16821, 0.866881),
                new Point(-0.1036, 0.839366),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer(0.1));
        }
    }
}
