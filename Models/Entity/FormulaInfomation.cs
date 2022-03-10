using System;
namespace DynamicFormula.Models.Entity
{
    public class FormulaInfomation
    {
        public FormulaInfomation(string expression, List<VariableInfomation> expressVariables, string condition, List<VariableInfomation> conditionVariables, int formulaLevel)
        {
            Expression = expression;
            ExpressionVariables = expressVariables;
            Condition = condition;
            ConditionVariables = conditionVariables;
        }

        public FormulaInfomation()
        {
            ExpressionVariables = new List<VariableInfomation>();
            ConditionVariables = new List<VariableInfomation>();
        }

        /// <summary>
        /// Công thức
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Danh sách biến số của công thức
        /// </summary>
        public List<VariableInfomation> ExpressionVariables { get;  set; }

        /// <summary>
        /// Điều kiện kích hoạt phép tính
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Danh sách biến số của điều kiện kích hoạt
        /// </summary>
        public List<VariableInfomation> ConditionVariables { get;  set; }



    }
}

