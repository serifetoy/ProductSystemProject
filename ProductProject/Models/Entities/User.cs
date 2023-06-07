using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProject.Models.Entities
{
    [Table("Users")]
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public UserType UserType { get; set; }
        public GenderType? GenderType { get; set; }

        public List<Address> Addresses { get; set; }
    }

    public enum GenderType : byte 
    {
        Female = 1,
        Male
    }
    public enum UserType : byte //default value is integer, i use byte so as not to take up space
    {
        User = 1,
        Seller,
        Customer
    }
}
