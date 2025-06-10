using DACN.Models;
using DACN.Views.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly CarrentalDbContext _context;
        public CustomersController(CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var c = _context.Customers.OrderBy(b => b.CustomerId).ToList();
            return View(c);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FullName,Password,PhoneNumber,Email")] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Customer.FullName = DACN.Views.Utilities.Function.TitleSlugGenerationAlias(Customer.FullName);
                _context.Add(Customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Customer);
        }

        // GET: Admin/Customers/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCustomer = await _context.Customers.FindAsync(id);
            if (tbCustomer == null)
            {
                return NotFound();
            }
            return View(tbCustomer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FullName,Password,PhoneNumber,Email")] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Customer.FullName = DACN.Views.Utilities.Function.TitleSlugGenerationAlias(Customer.FullName);
               
                _context.Customers.Update(Customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Customer);
        }

        // GET: Admin/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCustomer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (tbCustomer == null)
            {
                return NotFound();
            }

            return View(tbCustomer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCustomer = await _context.Customers.FindAsync(id);
            if (tbCustomer != null)
            {
                _context.Customers.Remove(tbCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
