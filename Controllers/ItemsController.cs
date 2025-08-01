using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers {
    public class ItemsController : Controller {
        public IActionResult Index() {
            var Item = new Item() { Name = "Sample Item" };
            return View(Item);
        }
    }
}
