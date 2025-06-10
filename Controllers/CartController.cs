using DACN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Controllers
{
    public class CartController : Controller
    {
        private readonly CarrentalDbContext _context;
        public CartController(CarrentalDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
