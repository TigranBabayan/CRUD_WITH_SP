using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_WITH_SP.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public int? ProductCount { get; set; }
        public decimal Price { get; set; }
    }
}
