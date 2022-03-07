using DynamicFormula.Services;
using DynamicFormula.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFormula.Controllers;

[ApiController]
[Route("[controller]")]
public class FormulaController : ControllerBase
{
    
    private readonly ILogger<FormulaController> _logger;
    private readonly ICalculatorService _calculatorService;

    public FormulaController(ILogger<FormulaController> logger, ICalculatorService calculatorService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    [HttpPost(Name = "calculate")]
    public double Post(FormularPostModels values)
    {
        Example.Datas = values.Data;
        Example.Formulas = values.Formula;
        var result = _calculatorService.Calculator(values.Name);
        return result;
    }
}

