﻿using System;
using DynamicFormula.Helper;
using DynamicFormula.Models;
using DynamicFormula.Models.Entity;
using DynamicFormula.Repository;
using DynamicFormula.ViewModels;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicFormula.Services
{
    public class CalculatorService : ICalculatorService
    {
        private const string _atomName = "RESULT";
        //private readonly ICalculatorConfigRepository _repo;

        public CalculatorService()
        {
            //_repo = repo;
        }

        public async Task<double> Calculator(string name)
        {
            return await Run(name);
        }


        public async Task<double> Run(string name)
        {
            Console.WriteLine($"START");
            var r = await RunExpression(name, Example.Datas);
            Console.WriteLine($"END: {Convert.ToDouble(r)}");
            return Convert.ToDouble(r);
        }
        private async Task<object> RunExpression(string name, object objectContainValue)
        {
            //seeddata
            var seedData = new SeedData.SeedDataModel();
            objectContainValue = seedData.SalesProducts;
            var calConfig = seedData.CalculatorConfigs.FirstOrDefault();

            Console.WriteLine($"RunExpression: {name}");
            //var calConfig = await GetFormulaConfig(name);
            double total = 0;
            if (calConfig == null) return 0;

            var formulars = calConfig.Formulas.Where(formularInfomation => TriggerChecking(formularInfomation, objectContainValue));
            if (formulars.Any()) return 0;

            foreach (var item in formulars)
            {
                total += (double)(GetResult(item, objectContainValue));
            }
            return total;
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
        private async void CreateCalculationEngineContext(object objectContainValue, List<VariableInfomation> variables, ExpressionContext context)
        {
            Dictionary<string, object?>? variableDictionary = PasreObjectContainValueToDictionary(objectContainValue);
            var variablesGroups = variables.GroupBy(x => x.Type);
            context.Imports.AddType(typeof(CustomFunction));
            foreach (var variableGroup in variablesGroups)
            {
                switch (variableGroup.Key)
                {
                    case VariableType.Formula:
                     
                        foreach (var variable in variableGroup.Distinct())
                        {
                            // Lấy tham số là một công thức tính
                            // Tính toán dựa trên công thức tính
                            // Đưa vào tham số cùng kết quả.
                            context.Variables.Add(variable.Name, await RunExpression(variable.Name, objectContainValue));
                        }
                        break;
                    case VariableType.Variable:
                        foreach (var variable in variableGroup)
                        {
                            List<object> arr;
                            //Kiem tra xem variable do co phai lai array ko?
                            try
                            {
                                arr = JsonConvert.DeserializeObject<List<object>>(variableDictionary.GetValueOrDefault(variable.Name).ToString());
                                context.Variables.Add(variable.Name, arr);
                            }
                            catch //Neu ko phai array thi add danng variable binh thuong
                            {
                                context.Variables.Add(variable.Name, variableDictionary.GetValueOrDefault(variable.Name));
                            }

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
            Dictionary<string, object> obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonObject);
            var dictionary = JObject.Parse(jsonObject)
                .Descendants()
                .OfType<JValue>()
                .ToDictionary(jv => jv.Path, jv => jv.Value);
            return dictionary;
        }

        private async Task<CalculatorConfig> GetFormulaConfig(string name)
        {
            //return await _repo.GetCalculatorConfigsByNameAsync(name);
            return Example.Formulas.FirstOrDefault(x => x.Name == name);
        }
    }

    public class DeserializedObject
    {
        public string ProcessLevel { get; set; }
        public object Segments { get; set; }
    }
}

