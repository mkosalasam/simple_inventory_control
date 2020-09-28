using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlClient.Data;
using InventoryControlClient.Models;
using InventoryControlClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlClient.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<IActionResult> Create([FromQuery]int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var stock = await _stockService.GetStockByProductId(productId.Value);

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
                await _stockService.CreateStock(stock);
                return RedirectToAction("index","Products");
            }
            return View(stock);
        }
    }
}
