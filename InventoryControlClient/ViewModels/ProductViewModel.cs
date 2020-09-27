using System.ComponentModel;

namespace InventoryControlClient.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("In Stock Quantity")]
        public double Quantity { get; set; }

        [DisplayName("Re-order level")]
        public double ReOrderLevel { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
