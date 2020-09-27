using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryControlClient.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [DisplayName("In Stock Quantity")]

        [Range(0,double.MaxValue, ErrorMessage = "Stock Quantity should be a positive value")]
        public double Quantity { get; set; }
        public Product Product { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}