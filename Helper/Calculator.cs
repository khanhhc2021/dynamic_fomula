using System;
using DynamicFormula.Models;
using DynamicFormula.Models.Entity;
using DynamicFormula.Repository;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicFormula.Helper
{
    public class Calculator : ICalculator
    {
        private const string _atomName = "RESULT";

        private readonly ICalculatorConfigRepository _repo;

        public Calculator(ICalculatorConfigRepository repo)
        {
            _repo = repo;
        }

        public async Task<double> Run(string name)
        {
            var r = await RunExpression(name, Example.Datas);
            return Convert.ToDouble(r);
        }
        private async Task<object> RunExpression(string name, object objectContainValue)
        {
            var calConfig = await GetFormulaConfig(name);
            if (calConfig == null) return 0;

            var formular = calConfig.Formulas.FirstOrDefault(formularInfomation => TriggerChecking(formularInfomation, objectContainValue));
            if (formular == null) return 0;

            return GetResult(formular, objectContainValue);
        }

        /// <summary>
        /// Hàm kiểm tra điều kiện kích hoạt phép tính
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="objectContainValue"></param>
        /// <returns></returns>
        private bool TriggerChecking(FormulaInfomation formulaInfomation, object objectContainValue)
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
        private object GetResult(FormulaInfomation formulaInfomation, object objectContainValue)
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
        /// <param name="variables"></param>
        /// <param name="context"></param>
        private void CreateCalculationEngineContext(object objectContainValue, List<VariableInfomation> variables, ExpressionContext context)
        {
            Dictionary<string, object?>? variableDictionary = PasreObjectContainValueToDictionary(objectContainValue);
            var variablesGroups = variables.GroupBy(x => x.Type);
            foreach (var variableGroup in variablesGroups)
            {
                switch (variableGroup.Key)
                {
                    case VariableType.Formula:
                        context.Imports.AddType(typeof(CustomFormula));
                        foreach (var variable in variableGroup.Distinct())
                        {
                            // Lấy tham số là một công thức tính
                            // Tính toán dựa trên công thức tính
                            // Đưa vào tham số cùng kết quả.
                            context.Variables.Add(variable.Name,  RunExpression(variable.Name, objectContainValue));
                        }
                        break;
                    case VariableType.Variable:
                        foreach (var variable in variableGroup)
                        {
                            context.Variables.Add(variable.Name, variableDictionary.GetValueOrDefault(variable.Name));
                        }
                        break;
                    default:
                        break;
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

        private async  Task<CalculatorConfig> GetFormulaConfig(string name)
        {
            return await _repo.GetCalculatorConfigsByNameAsync(name);
        }
    }
}

