namespace DynamicFormula.Models.SampleEntity
{
    public class Product
    {
        public Product()
        {

        }

        public string Code { get; set; }

        public decimal Cost { get; set; }

        public List<ElementaryProduct> ElementaryProducts { get; set; }
    }
}
