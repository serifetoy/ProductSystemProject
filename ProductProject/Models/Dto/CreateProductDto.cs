using System.ComponentModel.DataAnnotations;

namespace ProductProject.Models.Dto
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range (1,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
