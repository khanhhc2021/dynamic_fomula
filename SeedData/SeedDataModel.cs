using DynamicFormula.Models.Entity;
using DynamicFormula.Models.SampleEntity;

namespace DynamicFormula.SeedData
{
    public class SeedDataModel
    {
        public SeedDataModel()
        {
            SalesProducts = new()
            {
                new SalesProduct
                {
                    Code = "ASBD",
                    Cost = 0,
                    Products = new()
                    {
                        new Product
                        {
                            Code = "VCX",
                            Cost = 10000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "VC1",
                                    Cost = 2000
                                },
                                new()
                                {
                                    Code = "VC2",
                                    Cost = 3000
                                }
                            }
                        },
                        new Product
                        {
                            Code = "N",
                            Cost = 20000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "N1",
                                    Cost = 2000
                                },
                                new()
                                {
                                    Code = "N2",
                                    Cost = 3000
                                }
                            }
                        },
                        new Product
                        {
                            Code = "TNDS",
                            Cost = 5000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "TNDS1",
                                    Cost = 4000
                                },
                                new()
                                {
                                    Code = "NNTX",
                                    Cost = 1000
                                }
                            }
                        },
                        new Product
                        {
                            Code = "VCX",
                            Cost = 5000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "VC1",
                                    Cost = 2000
                                },
                                new()
                                {
                                    Code = "VC2",
                                    Cost = 3000
                                }
                            }
                        },
                        new Product
                        {
                            Code = "TNHGD",
                            Cost = 15000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "TNHGD1",
                                    Cost = 2000
                                },
                                new()
                                {
                                    Code = "TNHGD2",
                                    Cost = 3000
                                }
                            }
                        },
                        new Product
                        {
                            Code = "SK",
                            Cost = 5000,
                            ElementaryProducts = new()
                            {
                                new()
                                {
                                    Code = "SK1",
                                    Cost = 2000
                                },
                                new()
                                {
                                    Code = "SK2",
                                    Cost = 3000
                                }
                            }
                        }
                    }
                }
            };

            CalculatorInputs = new()
            {
                new("Code","Code", Models.VariableType.Variable),
                new("Cost", "Cost", Models.VariableType.Variable),
                new("Products.Code", "ProductCode", Models.VariableType.Variable),
                new("Products.Cost", "ProductCost", Models.VariableType.Variable),
                new("Products.ElementaryProducts.Code", "ElementaryProductsCode", Models.VariableType.Variable),
                new("Products.ElementaryProducts.Cost", "ElementaryProductsCost", Models.VariableType.Variable),
            };

            CalculatorConfigs = new()
            {
                new()
                {
                    Name = "BHCN",
                    DisplayName = "Tính phí bảo hiểm con người",
                    Formulas = new()
                    {
                        new()
                        {
                            Condition = $"Code = \"ASBD\" AND Products.Code = \"SK\" ",
                            ConditionVariables = new()
                            {
                                new("Code", Models.VariableType.Variable),
                                new("Products.Code", Models.VariableType.Variable)
                            },
                            Expression = "Sum(Products.ElementaryProducts.Cost)",
                            ExpressionVariables = new()
                            {
                                new("Products.ElementaryProducts.Cost", Models.VariableType.Variable),
                                new("SUM", Models.VariableType.Formula)
                            }
                        },
                        new()
                        {
                            Condition = $"Code = \"ASBD\" AND.Products.Code = \"TNHGD\" ",
                            ConditionVariables = new()
                            {
                                new("Code", Models.VariableType.Variable),
                                new("Products.Code", Models.VariableType.Variable)
                            },
                            Expression = "",
                            ExpressionVariables = new()
                            {

                            }
                        }
                    }
                }
            };
        }

        public List<SalesProduct> SalesProducts { get; set; }

        public List<CalculatorInput> CalculatorInputs { get; set; }

        public List<CalculatorConfig> CalculatorConfigs { get; set; }
    }
}
