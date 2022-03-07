using System;
using DynamicFormula.Helper;

namespace DynamicFormula.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculator _calculator;

        public CalculatorService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public async Task<double> Calculator(string name)
        {
            return await _calculator.Run(name);
        }
    }
}

