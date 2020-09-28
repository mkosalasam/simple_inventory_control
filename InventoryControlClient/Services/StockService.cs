using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlClient.Data;
using InventoryControlClient.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlClient.Services
{
    public class StockService: IStockService
    {
        private readonly InventoryDbContext _context;

        public StockService(InventoryDbContext context)
        {
            _context = context;
        }
        public Task<Stock> GetStockByProductId(int productId)
        {
            return _context.Stock.Include(s => s.Product)
                .Where(s => s.ProductId == productId)
                .OrderBy(s => s.CreatedOn).LastOrDefaultAsync();
        }

        public Task CreateStock(Stock stock)
        {
            // Update the product Current quantity
            var product = _context.Product.Single(p => p.Id == stock.ProductId);
            product.CurrentQuantity = stock.Quantity;
            product.LastUpdatedOn = DateTime.Now;
            _context.Update(product);

            // Add Stock
            stock.CreatedOn = DateTime.Now;
            _context.Add(stock);
            return _context.SaveChangesAsync();
        }
    }
}
