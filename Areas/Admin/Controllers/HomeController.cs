using Microsoft.AspNetCore.Mvc;

namespace DACN.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View("Index", "Login");
        }
    }
}
