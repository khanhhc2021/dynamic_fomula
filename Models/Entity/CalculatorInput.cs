namespace DynamicFormula.Models.Entity
{
    public class CalculatorInput
    {
        public CalculatorInput(string name, string displayName, VariableType type)
        {
            Name = name;
            DisplayName = displayName;
            Type = type;
        }

        protected CalculatorInput()
        {

        }

        /// <summary>
        /// Tên
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Tên hiển thị UI
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Loại biến
        /// </summary>
        public VariableType Type { get; private set; }

        public VariableCatalogy VariableCategory { get; private set; }
    }
}
