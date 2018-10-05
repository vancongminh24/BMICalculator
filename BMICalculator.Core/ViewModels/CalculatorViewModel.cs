using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Core.Services;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels
{
    class CalculatorViewModel : MvxViewModel
    {
        readonly ICalculatorService _calculatorService;

        public CalculatorViewModel(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

                    
        }

        private double _height;

        public double Height
        {
            get => _height;
            set
            {
                _height = value;

            }
        }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;

            }
        }
    }
}
