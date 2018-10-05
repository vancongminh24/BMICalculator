using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.Core.Services
{
    public interface ICalculatorService
    {
        double BMICalculation(double weight, double height);
    }
}
