using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers {
    public class ItemsController : Controller {
        private readonly MyAppDbContext _context;

        public ItemsController(MyAppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var items = await _context.Items.ToListAsync(); // Retrieve all items from the database
            //When retrieving data from the database, it is a good practice to use asynchronous methods to avoid blocking the main thread.
            return View(items);
        }

        public IActionResult Create() {
            return View();
        }
    }
}
