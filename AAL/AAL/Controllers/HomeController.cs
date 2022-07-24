using AAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AALContext _context;
     
        public HomeController(ILogger<HomeController> logger, AALContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }

        public IActionResult AboutUs()
        {
            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }
        public IActionResult ContactUs()
        {
            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.CategoryList = _context.Categories.ToList();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}