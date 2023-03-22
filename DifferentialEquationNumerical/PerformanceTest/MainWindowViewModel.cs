using PerformanceTest.Command;
using PerformanceTest.Models;
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
        private InitialDataModelDiffEquation initialDataModelDiffEquation;
        private double evaluationTime;
        private double evaluationTime2;


        public InitialDataModelDiffEquation InitialDataModelDiffEquation
        {
            get => initialDataModelDiffEquation;
            set
            {
                initialDataModelDiffEquation = value;
                OnPropertyChanged();
            }
        }

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


        public ICommand EvaluationFunctionCommand
        {
            get => evluationFunctionCommand;
        }


        public MainWindowViewModel()
        {
           
            evluationFunctionCommand = new RelayCommand(evaluate);
            InitialDataModelDiffEquation = new InitialDataModelDiffEquation();
        }

        private async void evaluate(object obj)
        {
            var sw1 = new Stopwatch();
            sw1.Start();


            switch (InitialDataModelDiffEquation.TypeNumericalSolve)
            {
                case TypeNumericalSolve.Eiler:
                    DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler(
                      InitialDataModelDiffEquation.X0,
                      InitialDataModelDiffEquation.Y0,
                      InitialDataModelDiffEquation.Step,
                      InitialDataModelDiffEquation.AmountOfSteps,
                      ExampleDiffEquation);
                    break;
                case TypeNumericalSolve.ImprovedEiler:
                    DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler(
                        InitialDataModelDiffEquation.X0,
                        InitialDataModelDiffEquation.Y0,
                        InitialDataModelDiffEquation.Step,
                        InitialDataModelDiffEquation.AmountOfSteps,
                        ExampleDiffEquation);
                    break;
                case TypeNumericalSolve.RyngeKuty:
                    DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte(
                        InitialDataModelDiffEquation.X0,
                        InitialDataModelDiffEquation.Y0,
                        InitialDataModelDiffEquation.Step,
                        InitialDataModelDiffEquation.AmountOfSteps,
                        ExampleDiffEquation);
                    break;
            }

            sw1.Stop();
            EvaluationTime2 = sw1.Elapsed.TotalMilliseconds;


            var sw = new Stopwatch();
            sw.Start();

            switch (InitialDataModelDiffEquation.TypeNumericalSolve)
            {
                case TypeNumericalSolve.Eiler:
                   await DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_Eiler_Async(
                        InitialDataModelDiffEquation.Expression,
                        InitialDataModelDiffEquation.X0,
                        InitialDataModelDiffEquation.Y0,
                        InitialDataModelDiffEquation.Step,
                        InitialDataModelDiffEquation.AmountOfSteps,
                        DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation_DifferentialEquation);
                    break;
                case TypeNumericalSolve.ImprovedEiler:
                    await DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_ImpEiler_Async(
                        InitialDataModelDiffEquation.Expression,
                        InitialDataModelDiffEquation.X0,
                        InitialDataModelDiffEquation.Y0,
                        InitialDataModelDiffEquation.Step,
                        InitialDataModelDiffEquation.AmountOfSteps,
                        DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation_DifferentialEquation);
                    break;
                case TypeNumericalSolve.RyngeKuty:
                    await DifferentialEquationNumerical.DifferentialEquation.CalculateDifferentialEquation_EnumerableReturn_RyngeKytte_Async(
                        InitialDataModelDiffEquation.Expression,
                        InitialDataModelDiffEquation.X0,
                        InitialDataModelDiffEquation.Y0,
                        InitialDataModelDiffEquation.Step,
                        InitialDataModelDiffEquation.AmountOfSteps,
                        DifferentialEquationNumerical.PythonCalculationClass.PythonCalculation_DifferentialEquation);
                    break;
            }
           
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
