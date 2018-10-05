using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.Core.Services
{
    class BMICalculatorService : IBMICalculatorService
    {
        public double CalculateBMI(double weight, double height)
        {
            return weight / (height*height);
        }
    }
}
