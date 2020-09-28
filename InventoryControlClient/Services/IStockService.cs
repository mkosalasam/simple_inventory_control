using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlClient.Models;

namespace InventoryControlClient.Services
{
    public interface IStockService
    {
        Task<Stock> GetStockByProductId(int productId);
        Task CreateStock(Stock stock);
    }
}
