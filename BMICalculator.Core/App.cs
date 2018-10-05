using System;
using System.Collections.Generic;
using System.Text;
using BMICalculator.Core.Services;
using BMICalculator.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace BMICalculator.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ICalculatorService, CalculatorService>();

            RegisterAppStart<CalculatorViewModel>();
        }
    }
}
