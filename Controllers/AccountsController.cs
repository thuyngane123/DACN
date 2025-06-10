using DACN.Models;
using DACN.Views.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Controllers
{
    public class AccountsController : Controller
    {
        private readonly CarrentalDbContext _context;
        public AccountsController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //kiem tra trang thai dang nhap
            if (!Function.IsLogin())
            {

                return RedirectToAction("Index", "Login", new { returnUrl = HttpContext.Request.Path });
            }
            // Lấy ID khách hàng từ session hoặc hệ thống xác thực
            var customerId = Function._AccountId;

            // Truy vấn thông tin khách hàng từ database
            var customer = _context.Customers
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect nếu không tìm thấy khách hàng
            }
            ViewBag.Order = _context.CarRentalOrders.Include(i => i.Status).Where(p => p.CustomerId == customerId).ToList();
            // Truyền dữ liệu khách hàng sang View

            return View(customer);

        }

       
    }
}
