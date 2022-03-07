using System;
using DynamicFormula.Models.Entity;

namespace DynamicFormula.ViewModels
{
    public class FormularPostModels
    {
        public string Name { get; set; }
        public TestData Data { get; set; }
        public List<CalculatorConfig>  Formula { get; set; }

    }
}

