using System;
using DynamicFormula.Models;
using DynamicFormula.Models.Entity;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicFormula.Helper
{
    public static class Calculator
    {
        private const string _atomName = "RESULT";

        //public static object Calculating(FormulaInfomation formulaInfomation, object objectContainValue)
        //{
        //        object result = GetResult(foundCalculatorConfig, objectContainValue);
        //        return CalculatingWithCustomFunction(foundCalculatorConfig, result);
        //}

        /// <summary>
        /// áp dụng customFunctions được khai báo ở Class CustomFunctions
        /// </summary>
        /// <param name="foundCalculatorConfig"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        //public static object CalculatingWithCustomFunction(FormulaInfomation foundCalculatorConfig, object result)
        //{
        //    if (string.IsNullOrEmpty(foundCalculatorConfig.CustomFunction))
        //        return result;
        //    ExpressionContext context = new ExpressionContext();
        //    context.Imports.AddType(typeof(CustomFunctions));
        //    IDynamicExpression e = context.CompileDynamic($"{foundCalculatorConfig.CustomFunction}({result})");
        //    return e.Evaluate();
        //}


        /// <summary>
        /// Hàm kiểm tra điều kiện kích hoạt phép tính
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="objectContainValue"></param>
        /// <returns></returns>
        public static bool TriggerChecking(FormulaInfomation formulaInfomation, object objectContainValue)
        {
            ExpressionContext ec = new();

            CreateCalculationEngineContext(objectContainValue, formulaInfomation.ConditionVariables, ec);
            var e = ec.CompileGeneric<bool>(formulaInfomation.Condition);
            return e.Evaluate();
        }

        /// <summary>
        /// Hàm tính toán dựa trên thiết lập công thức tính
        /// </summary>
        /// <param name="calculatorConfig"></param>
        /// <param name="objectContainValue"></param>
        /// <returns></returns>
        public static object GetResult(FormulaInfomation formulaInfomation, object objectContainValue)
        {
            CalculationEngine ce = new();
            ExpressionContext context = new();
            context.Options.RealLiteralDataType = RealLiteralDataType.Double;
            CreateCalculationEngineContext(objectContainValue, formulaInfomation.ExpressionVariables, context);
            ce.Add(_atomName, formulaInfomation.Expression, context);
            object calculatorResult = ce.GetResult(_atomName);
            return calculatorResult;
        }

        /// <summary>
        /// Tạo Context với tham số và giá trị của tham số được lấy trong ObjectContainValue
        /// </summary>
        /// <param name="objectContainValue"></param>
        /// <param name="formulaVariables"></param>
        /// <param name="context"></param>
        static void CreateCalculationEngineContext(object objectContainValue, List<VariableInfomation> formulaVariables, ExpressionContext context)
        {
            Dictionary<string, object?>? variableDictionary = PasreObjectContainValueToDictionary(objectContainValue);
            // Chi add 1 lan thoi, add > 1 lan ham do se bi loi ambiguous method
            bool customFomulaAdded = false;
            foreach (var item in formulaVariables)
            {
                if (variableDictionary.ContainsKey(item.Name) && item.Type == VariableType.Variable)
                {
                    context.Variables.Add(item.Name, variableDictionary.GetValueOrDefault(item.Name));
                }
                else if (item.Type == VariableType.Formula && !customFomulaAdded)
                {
                    context.Imports.AddType(typeof(CustomFormula));
                    customFomulaAdded = true;
                    // Lấy tham số là một công thức tính
                    // Tính toán dựa trên công thức tính
                    // Đưa vào tham số cùng kết quả.
                }

            }
        }

        /// <summary>
        /// hàm convert object chứ giá trị thành dạng Dictionary<string, object?>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parentName"></param>
        /// <returns></returns>
        static Dictionary<string, object?> PasreObjectContainValueToDictionary(object value)
        {
            var jsonObject = JsonConvert.SerializeObject(value);
            var dictionary = JObject.Parse(jsonObject)
                .Descendants()
                .OfType<JValue>()
                .ToDictionary(jv => jv.Path, jv => jv.Value);
            return dictionary;
        }
    }
}

