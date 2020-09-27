using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryControlClient.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double ReOrderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public List<Stock> Stocks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
