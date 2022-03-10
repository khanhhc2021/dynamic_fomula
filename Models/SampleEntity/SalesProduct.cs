namespace DynamicFormula.Models.SampleEntity
{
    public class SalesProduct
    {
        public SalesProduct()
        {

        }
        public string Code { get; set; }

        public decimal Cost { get; set; }

        public List<Product> Products { get; set; }
    }
}
