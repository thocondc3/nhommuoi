using Microsoft.AspNetCore.Mvc;
using nhom10.Models;
using System.Diagnostics;

namespace nhom10.Controllers
{
    public class HomeController : Controller
    {
        private readonly Nhom10Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Nhom10Context context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.productCategories = _context.TbProductCategories.ToList();
            ViewBag.productNew = _context.TbProducts.Where(m => m.IsNew).ToList();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
