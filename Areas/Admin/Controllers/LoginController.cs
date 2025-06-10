using DACN.Models;
using DACN.Views.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly CarrentalDbContext _context;
        public LoginController(CarrentalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]

        

        [HttpPost]
        public IActionResult Index(Account model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Message = "Vui lòng nhập đầy đủ thông tin.";
                return View(model);
            }

            // Kiểm tra tài khoản trong DB
            var check = _context.Accounts
                .FirstOrDefault(m => m.Email == model.Email && m.Password == model.Password);

            if (check == null)
            {
                ViewBag.Message = "Sai email hoặc mật khẩu!";
                return View(model);
            }

            Function._Message = string.Empty;
            Function._AccountId = check.AccountId;
            Function._UserName = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

    }
}
