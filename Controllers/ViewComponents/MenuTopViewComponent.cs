using DACN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Views.Shared.Components
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly CarrentalDbContext _context;

        public MenuTopViewComponent(CarrentalDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Menus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));

        }
    }
}
