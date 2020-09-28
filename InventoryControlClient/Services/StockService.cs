using System;
using System.Collections.Generic;
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
            stock.CreatedOn = DateTime.Now;
            _context.Add(stock);
            return _context.SaveChangesAsync();
        }
    }
}
