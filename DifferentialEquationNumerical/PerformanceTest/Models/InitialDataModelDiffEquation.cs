﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest.Models
{
    public class InitialDataModelDiffEquation : INotifyPropertyChanged
    {
        private double y0 = 1;
        private TypeNumericalSolve typeNumericalSolve = TypeNumericalSolve.Eiler;
        private double x0 = 0;
        private double step = 0.1;
        private int amountOfSteps = 100;

        private string expression = "dy=pow(x,2)-2*y";


        public double X0
        {
            get => x0;
            set
            {
                if (x0 == value) return;
                x0 = value;
                OnPropertyChanged();
            }
        }

        public double Step
        {
            get => step;
            set
            {
                if (step == value) return;
                step = value;
                OnPropertyChanged();
            }
        }

        public int AmountOfSteps
        {
            get => amountOfSteps;
            set
            {
                if (amountOfSteps == value) return;
                amountOfSteps = value;
                OnPropertyChanged();
            }
        }

        public string Expression
        {
            get => expression;
            set
            {
                if (expression == value) return;
                expression = value;
                OnPropertyChanged();
            }
        }

        public double Y0
        {
            get => y0;
            set
            {
                if (y0 == value) return;
                y0 = value;
                OnPropertyChanged();
            }
        }

        public TypeNumericalSolve TypeNumericalSolve
        {
            get => typeNumericalSolve;
            set
            {
                if(typeNumericalSolve == value) return; 
                typeNumericalSolve = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
