using DACN.Models;
using DACN.Views.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CarrentalDbContext _context;

        public ProductController(CarrentalDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var cars = _context.Cars.ToList(); 
            return View(cars);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.carType = new SelectList(_context.CarTypes, "TypeId", "CarTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                car.Alias = Function.TitleSlugGenerationAlias(car.CarName); // nên tạo Alias ở đây
                _context.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carType = new SelectList(_context.CarTypes, "TypeId", "CarTypeName", car.TypeId);
            return View(car);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }
            var carType = (from c in _context.CarTypes
                           select new SelectListItem()
                           {
                               Text = c.CarTypeName,
                               Value = c.TypeId.ToString(),
                           }).ToList();
            carType.Insert(0, new SelectListItem()
            {
                Text = "--select--",
                Value = string.Empty,
            });
            ViewBag.carType = carType;
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car c)
        {
            if (ModelState.IsValid)
            {
                c.Alias = DACN.Views.Utilities.Function.TitleSlugGenerationAlias(c.CarName);

                _context.Cars.Update(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        [HttpPost]
        public IActionResult Delete (int id)
        {
            var deleCar = _context.Cars.Find(id);
            if (deleCar == null) {
                return NotFound();
            }
            _context.Cars.Remove(deleCar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
