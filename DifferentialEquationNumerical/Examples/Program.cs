// See https://aka.ms/new-console-template for more information
using DifferentialEquationNumerical;


var difequation = "dy=pow(x,2)-2*y";
var simpleequation = "y=pow(x,2)-2";

var difList = DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler(difequation, 0, 1, 0.1, 10, PythonCalculationClass.PythonCalculation_DifferentialEquation);

var simpList = SimpleEquation.CalculateSimpleEquation(simpleequation, 0, 0.1, 10, PythonCalculationClass.PythonCalculation);

Console.WriteLine("\nDiff equation");
Console.WriteLine(difequation);

foreach (var item in difList)
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("\n\nSimple equation");
Console.WriteLine(simpleequation);

foreach (var item in simpList)
{
    Console.WriteLine(item.ToString());
}
