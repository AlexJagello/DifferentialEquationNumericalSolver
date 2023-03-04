namespace TestProject
{
    [TestClass]
    public class UnitTestDynamicCalculation
    {
        [TestMethod]
        public void TestPythonCalculation()
        {
           var value = DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation("y=2*x+2",3);

           Assert.AreEqual(8, value);
        }

        [TestMethod]
        public void TestPythonCalculationDifferential() 
        {
            var value = DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation_DifferentialEquation("dy=2*x+y+2", 3, 2);

            Assert.AreEqual(10, value);
        }
    }
}