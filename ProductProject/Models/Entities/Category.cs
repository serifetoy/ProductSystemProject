﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProject.Models.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Products { get; set; }
    }
}
