using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using DACN.Views.Utilities;
namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(Account acc) 
        {
            if (acc == null) {
                return NotFound();
            }
            //kiem tra su ton tai cua email trong DB
            var check = _context.Accounts.Where(m=> m.Email == acc.Email).FirstOrDefault();
            if (check != null) {
                //hien thi thong bao 
                Function._MessageEmail = "Email đã được sử dụng!";
                return RedirectToAction("Index", "Register");
            }
            //neu khong thi them vao DB
            Function._MessageEmail = string.Empty;
          
            _context.Add(acc);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
