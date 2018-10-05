using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.Core.Services
{
    public interface IBMICalculatorService
    {
        double CalculateBMI(double weight, double height);
    }
}
