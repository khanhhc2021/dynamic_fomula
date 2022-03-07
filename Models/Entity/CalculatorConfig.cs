using System;
namespace DynamicFormula.Models.Entity
{
    public class CalculatorConfig
    {

        public  CalculatorConfig()
        {
            Formulas = new List<FormulaInfomation>();
        }

        /// <summary>
        /// Tên hiển thị của phép tính
        /// </summary>
        public string DisplayName { get;  set; }

        /// <summary>
        /// Tên phép tính
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Danh sách công thức
        /// </summary>
        public List<FormulaInfomation> Formulas { get;  set; }
    }
}

