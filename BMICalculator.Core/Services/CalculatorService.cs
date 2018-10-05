using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.Core.Services
{
    class CalculatorService : ICalculatorService
    {
        public double BMICalculation(double weight, double height)
        {
            return weight / (height * height);
        }
    }
}
