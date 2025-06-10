﻿using DACN.Models;
using DACN.Views.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DACN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly CarrentalDbContext _context;
        public BlogsController (CarrentalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var blog = _context.Blogs.OrderBy(b=>b.BlogId).ToList();
            return View(blog);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog b)
        {
            if (ModelState.IsValid)
            {
                b.Alias = DACN.Views.Utilities.Function.TitleSlugGenerationAlias(b.Title);
                b.CreatedBy = DACN.Views.Utilities.Function._UserName;
                b.CreatedDate = DateTime.Now;
                _context.Blogs.Add(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog b)
        {
            if (ModelState.IsValid) {
                b.Alias = DACN.Views.Utilities.Function.TitleSlugGenerationAlias(b.Title);
                b.ModifiedBy = DACN.Views.Utilities.Function._UserName;
                b.ModifiedDate = DateTime.Now;
                _context.Blogs.Update(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public IActionResult Delete(int? id) { 
            if (id == 0 || id == null)
            {
                return NotFound(); 
            }
            var blog = _context.Blogs.Find(id);
            if (blog == null) {
                return NotFound();
            }
            return View(blog);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleBlog = _context.Blogs.Find(id);
            if (deleBlog == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(deleBlog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
