using System;
using DynamicFormula.Helper;

namespace DynamicFormula.Services
{
    public class CalculatorService:ICalculatorService
    {
        public CalculatorService()
        {
           
        }
        public double Calculator(string name)
        {
            return CustomFormula.Run(name);
        }
    }
}

