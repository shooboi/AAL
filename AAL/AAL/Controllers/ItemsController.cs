using AAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AAL.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AALContext _context;

        public ItemsController(AALContext context)
        {
            _context = context;
        }
        public IActionResult Index(Category? category)
        {
            ViewData["PageTitle"] = "All Products";
            //if (category.CatName)
            //{
               
            //} 
            var ItemList = _context.Items .ToList();
            return View(ItemList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Cat)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}
