using DynamicFormula.Models.Entity;

namespace DynamicFormula.Repository
{
    public class CalculatorConfigRepository : ICalculatorConfigRepository
    {
        public Task<CalculatorConfig> GetCalculatorConfigsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
