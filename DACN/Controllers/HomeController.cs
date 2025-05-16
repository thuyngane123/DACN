using System.Diagnostics;
using DACN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarrentalDbContext _context;

        public HomeController(CarrentalDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.productDealofDay = _context.Cars.Where(i => i.IsSale == true).OrderByDescending(i => i.CarId).ToList();
            ViewBag.Blog = _context.Blogs.Where(i => i.IsActive == true).ToList();
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
