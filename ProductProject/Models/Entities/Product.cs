using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProject.Models.Entities
{
    [Table("Products")]
    public class Product : BaseEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
