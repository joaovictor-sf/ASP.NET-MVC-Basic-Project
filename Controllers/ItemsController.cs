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
            var items = await _context.Items.Include(s => s.SerialNumber).ToListAsync(); // Retrieve all items from the database
            //When retrieving data from the database, it is a good practice to use asynchronous methods to avoid blocking the main thread.
            return View(items);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item) {// Bind the incoming data to the Item model
            if (ModelState.IsValid) {
                _context.Items.Add(item); // Add the new item to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(item); // If model state is invalid, return the same view with the item
        }

        public async Task<IActionResult> Edit(int id) {
            var item = await _context.Items.FindAsync(id); // Find the item by id
            if (item == null) {
                return NotFound("Item not found"); // Return 404 if item not found
            }
            return View(item); // Return the edit view with the item
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item) {
            if (id != item.Id) {
                return NotFound("Item ID mismatch"); // Return 404 if the id does not match
            }
            if (ModelState.IsValid) {
                _context.Update(item); // Update the item in the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(item); // If model state is invalid, return the same view with the item
        }
        public async Task<IActionResult> Delete(int id) {
            var item = await _context.Items.FindAsync(id); // Find the item by id
            if (item == null) {
                return NotFound("Item not found"); // Return 404 if item not found
            }
            return View(item); // Return the delete view with the item
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var item = await _context.Items.FindAsync(id); // Find the item by id
            if (item == null) {
                return NotFound("Item not found"); // Return 404 if item not found
            }
            _context.Items.Remove(item); // Remove the item from the context
            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }
    }
}
