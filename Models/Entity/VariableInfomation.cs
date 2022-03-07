using System;
namespace DynamicFormula.Models.Entity
{
    public class VariableInfomation
    {
        public VariableInfomation(string name, VariableType type)
        {
            Name = name;
            Type = type;
        }

        protected VariableInfomation()
        {

        }
        /// <summary>
        /// Tên biến
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Loại biến (Công thức or biến giá trị)
        /// </summary>
        public VariableType Type { get;  set; }
    }
}

