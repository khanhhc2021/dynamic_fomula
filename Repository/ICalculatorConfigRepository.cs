using DynamicFormula.Models.Entity;

namespace DynamicFormula.Repository
{
    public interface ICalculatorConfigRepository
    {
         Task<CalculatorConfig> GetCalculatorConfigsByNameAsync(string name);
    }
}
