﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryControlClient.Data;
using InventoryControlClient.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlClient.Services
{
    public class ProductService: IProductService
    {
        private readonly InventoryDbContext _context;

        public ProductService(InventoryDbContext context)
        {
            _context = context;
        }
        public Task<List<Product>> GetProducts()
        {
            return _context.Product.Include(p => p.Stocks).ToListAsync();
        }

        public Task<Product> GetProductById(int id)
        {
            return _context.Product.Include(p => p.Stocks)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> CreateProduct(Product product)
        {
            // Add Product
            product.CreatedOn = DateTime.Now;
            _context.Add(product);

            // Add 0 stock
            var stock = new Stock {Quantity = 0, Product = product};
            _context.Add(stock);

            await _context.SaveChangesAsync();
            return product.Id;
        }

        public Task UpdateProduct(Product product)
        {
            product.LastUpdatedOn = DateTime.Now;
            _context.Update(product);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
