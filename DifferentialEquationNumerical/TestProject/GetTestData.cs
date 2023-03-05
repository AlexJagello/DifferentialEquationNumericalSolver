using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestProject
{
    internal static class GetTestData
    {
        public static IList<DifferentialEquationNumerical.Models.Point> GetDataList(string fileName)
        {
            List<DifferentialEquationNumerical.Models.Point> list;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                list = JsonSerializer.Deserialize<List<DifferentialEquationNumerical.Models.Point>>(fs);
            }

            return list;
        }

        public static ICollection GetData(string fileName)
        {
            var list = new List<DifferentialEquationNumerical.Models.Point>();

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                list = JsonSerializer.Deserialize<List<DifferentialEquationNumerical.Models.Point>>(fs);
            }
            return list;
        }

    }
}
