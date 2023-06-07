using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProductProject.Models.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity<int>
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<OrderItem> Items { get; set; }

        [MaxLength(150)]
        public string Note { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Adress { get; set; }

        [NotMapped]
        public double? Total => Items?.Sum(x => x.Quantity * x.Price);//Cannot write to database

    }

    [Table("OrderItems")]
    public class OrderItem : BaseEntity<int>
    {

        [ForeignKey("ProductId")]
        public Product Product { get; set; } 
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public double Price { get; set; } 

    }
}
