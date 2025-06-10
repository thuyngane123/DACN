using DACN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Controllers
{
    public class ContactController : Controller
    {
        private readonly CarrentalDbContext _context;
        public ContactController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                Contact contact = new Contact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now
                };
                await _context.AddAsync(contact);
                await _context.SaveChangesAsync();

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
