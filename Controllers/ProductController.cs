using Azure.Core;
using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<Car> productRelated;
            if (TypeId.HasValue)
            {
                productRelated = _context.Cars
                                         .Where(c => c.TypeId == TypeId.Value)
                                         .ToList();
            }
            else
            {
                productRelated = _context.Cars.ToList();
            }

            ViewBag.productRelated = productRelated;
            ViewBag.Categories = _context.CarTypes.ToList();

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
        public async Task<IActionResult> Create(int carId, string name, string phone, string email, string detail)
        {
            try
            {
                CarReview review = new CarReview
                {
                    CarId = carId, // Lưu CarId vào review
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Detail = detail,
                    CreatedDate = DateTime.Now
                };
                await _context.AddAsync(review);
                await _context.SaveChangesAsync();

                return Json(new { status = true, review = review });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

    }
}
