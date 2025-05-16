using DACN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Controllers.ViewComponents
{
    public class BlogVIewComponent : ViewComponent
    {
        private readonly CarrentalDbContext _context;
        public BlogVIewComponent(CarrentalDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = _context.Blogs.Where(i => (bool)i.IsActive).ToList();
            return await Task.FromResult<IViewComponentResult>(View(item));
        }
    }
}
