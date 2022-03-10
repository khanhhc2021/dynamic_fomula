using DynamicFormula;
using DynamicFormula.Helper;
using DynamicFormula.Repository;
using DynamicFormula.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICalculatorService, CalculatorService>();
//builder.Services.AddSingleton<ICalculator, Calculator>();
builder.Services.AddSingleton<ICalculatorConfigRepository, CalculatorConfigRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

