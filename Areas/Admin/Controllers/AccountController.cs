using DACN.Models;
using DACN.Views.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly CarrentalDbContext _context;
        public AccountController(CarrentalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            
            var ID = Function._AccountId;
            var accID = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == ID);

            if (accID == null)
            {
                return NotFound();
            }

            return View(accID);
        }

        // Hành động để xử lý chỉnh sửa thông tin tài khoản

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Account userModel)
        {
            if (ModelState.IsValid)
            {
                var id = Function._AccountId;
                var user = await _context.Accounts.FirstOrDefaultAsync(u => u.AccountId == id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Username = userModel.Username;

                // Kiểm tra email có thay đổi và có tồn tại trong DB không
                if (userModel.Email != user.Email)
                {
                    var emailExists = await _context.Accounts.AnyAsync(p => p.Email == userModel.Email);
                    if (emailExists)
                    {
                        Function._MessageEmail = "Email đã tồn tại";
                        return View(userModel);
                    }
                    else
                    {
                        user.Email = userModel.Email;
                    }
                }

                user.Phone = userModel.Phone;
                Function._MessageEmail = string.Empty;

                // Lưu thay đổi vào DB
                await _context.SaveChangesAsync();
                Function._UserName = user.Username;
                Function._Email = user.Email;
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            }
            return View(userModel);
        }


    }
}
