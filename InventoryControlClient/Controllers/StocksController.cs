using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlClient.Data;
using InventoryControlClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlClient.Controllers
{
    public class StocksController : Controller
    {
        private readonly InventoryDbContext _context;

        public StocksController(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create([FromQuery]int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.Include(s => s.Product)
                .Where(s=>s.ProductId == productId)
                .OrderBy(s => s.CreatedOn).LastOrDefaultAsync();

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                stock.CreatedOn = DateTime.Now;
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction("index","Products");
            }
            return View(stock);
        }
    }
}
