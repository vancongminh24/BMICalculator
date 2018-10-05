using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels
{
    public class BMICalculatorViewModel : MvxViewModel
    {
        readonly IBMICalculatorService _bmiCalculatorService;
        private double _weight;
        private double _height;
        private double _bmi;

        public string WeightLabel => "Cân Nặng (kg)"; //same as method{}
        public string HeightLabel => "Chiều Cao (m)";
        public string BMILabel => "BMI";
        public string CalculateLabel => "Calculate";

        public BMICalculatorViewModel(IBMICalculatorService bmiCalculatorService)
        {
            _bmiCalculatorService = bmiCalculatorService;
            BmiButtonClickedCommand = new MvxCommand(CalculateBMI);
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            _weight = 0;
            _height = 0;
            
        }

        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;

            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
            }
        }

        public double BMI
        {
            get => _bmi;
            set => SetProperty(ref _bmi, value);
            //{
            //    _bmi = value;
            //    RaisePropertyChanged(() => BMI);
            //}
        }

        public IMvxCommand BmiButtonClickedCommand { get; set; }

        public void CalculateBMI()
        {
            BMI = _bmiCalculatorService.CalculateBMI(_weight, _height);
        }
    }
}
