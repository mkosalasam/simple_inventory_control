using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlClient.Models;

namespace InventoryControlClient.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int productId);
        Task<int> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
