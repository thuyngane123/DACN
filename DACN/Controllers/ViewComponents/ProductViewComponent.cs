using DACN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Controllers.Components
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly CarrentalDbContext _context;

        public ProductViewComponent(CarrentalDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Cars.Include(m => m.Type);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.CarId).ToList()));
        }

    }
}

