using DynamicFormula.Models.Entity;

namespace DynamicFormula.Helper
{
    public static class CustomFormula
    {
        public static double Run(string name)
        {
            Console.WriteLine($"CONG_THUC : {name}");
            var r = RunExpression(name, Example.Datas);
            Console.WriteLine($"KET_QUA : {r}");
            return Convert.ToDouble(r);
        }
        public static object RunExpression(string name, object objectContainValue)
        {
            Console.WriteLine($"Expression : {name} ......");
            var calConfig = GetFormulaConfig(name);
            if (calConfig == null) return 0;

            var formular = calConfig.Formulas.FirstOrDefault(formularInfomation => Calculator.TriggerChecking(formularInfomation, objectContainValue));
            if (formular == null) return 0;

            return Calculator.GetResult(formular, objectContainValue);

            //foreach (var f in calConfig.Formulas)
            //{
            //    var conditions = f.ConditionVariables.Where(x => x.Type == VariableType.Formula);
            //    foreach (var trigger in conditions)
            //    {
            //        f.Condition = f.Condition.Replace(trigger.Name, "RunExpression(\"" + trigger.Name + "\")");
            //    }
              
            //    Console.WriteLine($"Kiem tra dieu kien : {f.Condition}");
            //    bool checkCondition = true;
            //    if (!string.IsNullOrEmpty(f.Condition))
            //        checkCondition = Calculator.TriggerChecking(f, Example.Datas);
            //    Console.WriteLine($"Ket qua Kiem tra dieu kien : {f.Condition} : {checkCondition}");
            //    if (checkCondition)
            //    {
            //        var expression = f.ExpressionVariables.Where(x => x.Type == VariableType.Formula);
            //        foreach (var exp in expression)
            //        {
            //            f.Expression = f.Expression.Replace(exp.Name, "RunExpression(\"" + exp.Name + "\")");
            //        }
            //        Console.WriteLine($"FLEE RUNNING {f.Expression}");
            //        Console.WriteLine($"values : {Example.Datas}");
            //        string expresstion = f.Expression;
            //        var r = Calculator.GetResult(f, Example.Datas);

            //        Console.WriteLine();
            //        double d = 0;
            //        d = Convert.ToDouble(r);
            //        Console.WriteLine($"result {f.Expression}: {d}");
            //        result = d;
            //        return result;
            //    }
            //}
        }

        //// Declare a function that takes a variable number of arguments
        //public static bool RunCondition(string name, string id)
        //{
        //    var result = RunBase(name, id);
        //    bool d = false;
        //    d = Convert.ToBoolean(result);
        //    return d;
        //}
        //public static double RunExpression(string name, string id)
        //{
        //    var result = RunBase(name, id);
        //    double d = 0;
        //    d = Convert.ToDouble(result);
        //    return d;
        //}


        //private static FormulaInfomation GetFormulaById(string name,string id)
        //{
        //    CalculatorConfig c = GetFormulaConfig(name);
        //    var r = c.Formulas.FirstOrDefault(x => x.Id == id);
        //    return r;
        //}
        private static CalculatorConfig GetFormulaConfig(string name)
        {
            //test data
            //var listF = new List<FormulaInfomation> {
            //new FormulaInfomation(
            //expression: "InsuranceAmount * 1/100 ",
            //condition: "BenefitCode = \"QL001\"",
            //expressVariables: new List<VariableInfomation>
            //{
            //new VariableInfomation("InsuranceAmount", VariableType.Variable) },
            //    conditionVariables: new List<VariableInfomation>
            //        { new VariableInfomation("BenefitCode", VariableType.Variable)},formulaLevel: 0, customFunction: "Round"),


            //new FormulaInfomation(
            //expression: "InsuranceAmount * 2/100",
            //condition: "BenefitCode = \"QL002\"",
            //expressVariables: new List<VariableInfomation>
            //{
            //new VariableInfomation("InsuranceAmount", VariableType.Variable) },
            //    conditionVariables: new List<VariableInfomation>
            //        { new VariableInfomation("BenefitCode", VariableType.Variable)},formulaLevel: 0, customFunction: "Round"),

            //};
            ////test CT2
            //var listF2 = new List<FormulaInfomation> {
            //new FormulaInfomation(
            //expression: "CT1 + 1 ",
            //condition: "CT1 > 3",
            //expressVariables: new List<VariableInfomation>
            //{
            //new VariableInfomation("InsuranceAmount", VariableType.Variable),new VariableInfomation("CT1", VariableType.Formula) },
            //    conditionVariables: new List<VariableInfomation>
            //        { new VariableInfomation("CT1", VariableType.Formula)},formulaLevel: 0, customFunction: "Round"),


            //new FormulaInfomation(
            //expression: "CT1 + 2",
            //condition: "BenefitCode = \"QL002\"",
            //expressVariables: new List<VariableInfomation>
            //{
            //new VariableInfomation("InsuranceAmount", VariableType.Variable),new VariableInfomation("CT1", VariableType.Formula) },
            //    conditionVariables: new List<VariableInfomation>
            //        { new VariableInfomation("BenefitCode", VariableType.Variable)},formulaLevel: 0, customFunction: "Round"),

            //};

            //var calConfig = new List<CalculatorConfig> { new CalculatorConfig("CT1", "CT1", listF), new CalculatorConfig("CT2", "CT2", listF2) };
            var myObject = Example.Formulas;
            //using (StreamReader sr = File.OpenText("./Data/test.json"))
            //{
            //     myObject = JsonConvert.DeserializeObject<List<CalculatorConfig>>(sr.ReadToEnd());
            //}

            return myObject.FirstOrDefault(x => x.Name == name);
        }
    }
}

