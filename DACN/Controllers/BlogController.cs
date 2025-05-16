using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Controllers
{
    public class BlogController : Controller
    {
        private readonly CarrentalDbContext _context;
        public BlogController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        [Route("/blog/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }
            var blog = await _context.Blogs.Include(i => i.BlogComments).FirstOrDefaultAsync(i => i.BlogId == id);

            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.BlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);
        }
    }
}
