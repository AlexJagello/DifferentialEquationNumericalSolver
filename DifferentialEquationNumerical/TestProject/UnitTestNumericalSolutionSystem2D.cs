using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Point3D> expectedExplicit = new ObservableCollection<Point3D>()
        {
                new Point3D(0,1, 0),
                new Point3D(-0.14622, 0.983685, 0.2),
                new Point3D(-0.20658,0.947216, 0.4),
                new Point3D(-0.20739,0.905009, 0.6),
                new Point3D(-0.16826, 0.866913, 0.8),
                new Point3D(-0.10364, 0.839397, 1),
        };

        [TestMethod]
        public void TestDifferentialEquationSystem2D_Eiler_Dynamic()
        {
           var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
           var expected = new List<Point3D>() { 
            
                new Point3D(0,1, 0),
                new Point3D(-0.2,1, 0.2),
                new Point3D(-0.28,0.96, 0.4),
                new Point3D(-0.28,0.904, 0.6),
                new Point3D(-0.2288, 0.848, 0.8),
                new Point3D(-0.14688,0.80224, 1),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer3D(0.01));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_ImpEiler_Dynamic()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
            var expected = new List<Point3D>() {

                new Point3D(0, 1, 0),
                new Point3D(-0.18, 1, 0.2),
                new Point3D(-0.244, 0.962, 0.4),
                new Point3D(-0.2314, 0.9096, 0.6),
                new Point3D(-0.17048, 0.85846, 0.8),
                new Point3D(-0.08127, 0.818532, 1),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer3D(0.1));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_RyngeKytte_Dynamic()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
            var expected = new List<Point3D>() {

                new Point3D(0,1,0),
                new Point3D(-0.1462, 0.983667, 0.2),
                new Point3D(-0.20654, 0.947189, 0.4),
                new Point3D(-0.20734, 0.904977, 0.6),
                new Point3D(-0.16821, 0.866881, 0.8),
                new Point3D(-0.1036, 0.839366, 1),
           };

            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)result, new PointComparer3D(0.1));
        }




        [TestMethod]
        public void TestDifferentialEquationSystem2D_Eiler_Dynamic_Explicit()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_Eiler("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
          
            CollectionAssert.AreEqual(expectedExplicit, (System.Collections.ICollection)result, new PointComparer3D(0.1));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_ImpEiler_Dynamic_Explicit()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_ImpEiler("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);

            CollectionAssert.AreEqual(expectedExplicit, (System.Collections.ICollection)result, new PointComparer3D(0.1));
        }

        [TestMethod]
        public void TestDifferentialEquationSystem2D_RyngeKytte_Dynamic_Explicit()
        {
            var result = DifferentialEquationSystem2D.CalculateDifferentialEquation_2DSystem_EnumerableReturn_RyngeKytte("dy=-2*x-y+z", "dy=x", 0, 1, 0, 0.2, 6, PythonCalculationClass.PythonCalculation_DifferentialEquation_System2D);
          

            CollectionAssert.AreEqual(expectedExplicit, (System.Collections.ICollection)result, new PointComparer3D(0.1));
        }
    }
}
