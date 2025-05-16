using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Controllers
{
    public class ProductController : Controller
    {
        private readonly CarrentalDbContext _context;
        public ProductController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? TypeId)
        {
            var productRelated = _context.Cars.ToList();
            var categories = _context.CarTypes.ToList();
          
            ViewBag.productRelated = productRelated;
            ViewBag.categories = categories;
            return View();
        }
        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }
            var product = await _context.Cars.Include(i => i.Type).FirstOrDefaultAsync(m => m.CarId == id);
            
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productRelated = _context.Cars.Where(i => i.TypeId == product.TypeId && i.CarId != id).ToList();
            ViewBag.productRviews = _context.CarReviews.Where(r => r.CarId == product.CarId).ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Reviews(string name, string email, string detail, int id, int star)
        {
            try
            {
                
                CarReview r = new CarReview
                {
                    Name = name,

                    Email = email,
                    CreatedDate = DateTime.Now,
                    Detail = detail,
                    CarId = id,
                    Star = star

                };

                // Thêm vào DbSet và lưu vào cơ sở dữ liệu
                _context.CarReviews.Add(r);
                await _context.SaveChangesAsync(); // Sử dụng await để đảm bảo dữ liệu được lưu


                // Trả về dữ liệu của review vừa được thêm
                return Json(new
                {
                    //status = true,
                    name = r.Name,
                    email = r.Email,
                    detail = r.Detail,
                    star = r.Star

                });
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần) và trả về trạng thái thất bại
                return Json(new { status = false, message = ex.Message });
            }
        }

    }
}
