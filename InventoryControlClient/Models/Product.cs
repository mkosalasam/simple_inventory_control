using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryControlClient.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double ReOrderLevel { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [DefaultValue(0)]
        public double CurrentQuantity { get; set; }
        public List<Stock> Stocks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
