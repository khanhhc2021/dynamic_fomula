using System;
using DynamicFormula.Helper;

namespace DynamicFormula.Services
{
    public interface ICalculatorService
    {
        Task<double> Calculator(string name);
    }
}

