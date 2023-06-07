using System.ComponentModel.DataAnnotations;

namespace ProductProject.Models.Dto
{
    public class GetProductDto
    {// we dont use validation attiribute because we return exist product

        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
        public double PriceWithTax { get; set; }
    }
}
