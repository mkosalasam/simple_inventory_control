using System.Linq;
using InventoryControlClient.Models;
using InventoryControlClient.ViewModels;

namespace InventoryControlClient.Extensions
{
    public static class ProductModelExtension
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            var lastStock = product.Stocks.OrderBy(s => s.CreatedOn).LastOrDefault();
            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = lastStock?.Quantity ?? 0,
                ReOrderLevel = product.ReOrderLevel,
                UnitPrice = product.UnitPrice
            };
            return model;
        }
    }
}
