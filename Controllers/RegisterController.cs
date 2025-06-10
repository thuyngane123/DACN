using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CarrentalDbContext _context;

        public RegisterController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string username, string email, string password)
        {
            try
            {
                User customer = new User
                {
                    UserName = username,
                    Email = email,
                    Password = password
                };

                _context.Add(customer);
                _context.SaveChanges();

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
