using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAL.Models;
using Microsoft.AspNetCore.Authorization;
using AAL.Models.DTO;
using OfficeOpenXml;

namespace AAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ItemsController : Controller
    {
        private readonly AALContext _context;

        public ItemsController(AALContext context)
        {
            _context = context;
        }

        // GET: Admin/Items
        public async Task<IActionResult> Index()
        {
            var aALContext = _context.Items.Include(i => i.Cat).Include(i => i.Warehouse);
            return View(await aALContext.ToListAsync());
        }

        // GET: Admin/Items/Details/5
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

        // GET: Admin/Items/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseName");
            return View();
        }

        // POST: Admin/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Brand,Model,Desc,Img,Price,Stock,CatId,WarehouseId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", item.CatId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", item.WarehouseId);
            return View(item);
        }

        // GET: Admin/Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName", item.CatId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseName", item.WarehouseId);
            return View(item);
        }

        // POST: Admin/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Brand,Model,Desc,Img,Price,Stock,CatId,WarehouseId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", item.CatId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", item.WarehouseId);
            return View(item);
        }

        // GET: Admin/Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'AALContext.Items'  is null.");
            }
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
        public async Task<string> Upload(IFormFile file)

        {
            var path = await Utility.UploadFile(file, "ItemImages");
            return path;
        }

        public IActionResult DeleteFile(string filetodelete)
        {
            Utility.Delete(filetodelete, "ItemImages");
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    FileInfo path = new FileInfo(@"wwwroot/uploads");
                    if (!Directory.Exists(path.FullName))
                    {
                        Directory.CreateDirectory(path.FullName);
                    }

                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(path.FullName, fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    using (ExcelPackage excel = new ExcelPackage(filePath))
                    {
                        ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var item = new Item
                            {
                                ItemName = worksheet.Cells[row, 1].Value.ToString(),
                                Brand = worksheet.Cells[row, 2].Value.ToString(),
                                Model = worksheet.Cells[row, 3].Value.ToString(),
                                Desc = worksheet.Cells[row, 4].Value.ToString(),
                                Price = Convert.ToDecimal(worksheet.Cells[row, 6].Value),
                                Stock = Convert.ToInt32(worksheet.Cells[row, 7].Value)
                            };

                            if (item == null)
                            {
                                throw new Exception($"Item is null");
                            }
                            var result =  _context.Items.AddAsync(item);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = $"Error {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
