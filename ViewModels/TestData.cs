using System;
namespace DynamicFormula.ViewModels
{
    public class TestData
    {

        public decimal Cost { get; set; }

        public string Code { get; set; }

        public List<string> Products_Code { get; set; }
        public List<decimal> Products_ElementaryProducts_Cost { get; set; }

    }
}

