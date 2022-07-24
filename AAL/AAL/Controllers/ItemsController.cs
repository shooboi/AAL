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
        private async Task<IEnumerable<Category>> GetCategories()
        {
            var qr = (from c in _context.Categories select c)
             .Include(c => c.CatParent)
             .Include(c => c.InverseCatParent);

            var categories = (await qr.ToListAsync())
                             .Where(c => c.CatParent == null)
                             .ToList();
            return categories;
        }
        public async Task<IActionResult> Index(int? categoryId)
        {
            ViewBag.CategoryList = GetCategories();

            ViewData["PageTitle"] = "All Products";
            var ItemList = _context.Items.Where(cate=>cate.CatId == categoryId).ToList();
            
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
