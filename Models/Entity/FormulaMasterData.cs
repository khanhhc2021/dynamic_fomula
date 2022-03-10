using System;
namespace DynamicFormula.Models.Entity
{
    public class FormulaMasterData
    {
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public FormulaMasterDataType Type { get; set; }
        public string Query { get; set; }
    }
}

