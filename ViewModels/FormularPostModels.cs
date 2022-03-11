using System;
using DynamicFormula.Models.Entity;
using DynamicFormula.Models.SampleEntity;

namespace DynamicFormula.ViewModels
{
    public class FormularPostModels
    {
        public string Name { get; set; }
        public SalesProduct Data { get; set; }
        public List<CalculatorConfig>  Formula { get; set; }

    }
}

