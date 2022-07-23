using AAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly AALContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public HomeController(AALContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            int order = _context.Orders.Count();
            ViewBag.numOrder = order;
            ViewBag.numUser = _userManager.Users.ToList().Count();
            return View();
        }
    }
}
