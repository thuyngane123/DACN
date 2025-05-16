using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DACN.Controllers
{
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
        [HttpPost]
        public async Task<IActionResult> Create(string email, string password)
        {
            try
            {
                // Kiểm tra 
                var customer = await _context.Users
                    .FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

                if (customer != null)
                {
                    
                    return Json(new { status = true });
                }
                else
                {
                    
                    return Json(new { status = false, message = "Sai tên đăng nhập hoặc mật khẩu." });
                }
            }
            catch
            {
                return Json(new { status = false, message = "Có lỗi xảy ra, vui lòng thử lại." });
            }
        }
    }
}

