using PerformanceTest.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerformanceTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand evluationFunctionCommand;
        private double evaluationTime;
        private double evaluationTime2;

        public double EvaluationTime 
        {
            get => evaluationTime;
            set
            {
                evaluationTime = value;
                OnPropertyChanged();
            }
        }

        public double EvaluationTime2
        {
            get => evaluationTime2;
            set
            {
                evaluationTime2 = value;
                OnPropertyChanged();
            }
        }


        public ICommand EvluationFunctionCommand
        {
            get => evluationFunctionCommand;
        }


        public MainWindowViewModel()
        {
           
            evluationFunctionCommand = new RelayCommand(evaluate);

        }

        private void evaluate(object obj)
        {
            var sw = new Stopwatch();
            sw.Start();

            DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler("dy=pow(x,2)-2*y", 0, 1, 0.1, 10000,
                DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation_DifferentialEquation);

            sw.Stop();
            EvaluationTime = sw.Elapsed.TotalMilliseconds;

        }

        public double ExampleDiffEquation(double x, double y)
        {
            return Math.Round(Math.Pow(x,2) - 2*y, 6);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
