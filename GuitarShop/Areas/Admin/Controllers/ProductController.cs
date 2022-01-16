using GuitarShop.Data;
using GuitarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("[area]/[controller]/{id?}")]
        public IActionResult List(string id = "All")
        {
            var product = new CategoriesListModels
            {
                SelectedId = id,
                Categories = _context.Categories.OrderBy(m=>m.Name).ToList(),
                Products= _context.Products.Include(m=>m.Category).OrderBy(p=>p.ProductId).ToList()
            };
            return View(product);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var category = new CategoriesListModels();
           category.Categories= _context.Categories.OrderBy(c=>c.CategoryId).ToList();
            return View(category);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = new CategoriesListModels();

            product.Categories = _context.Categories.OrderBy(m => m.Name).ToList();              
            
            product.Product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
             return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = new CategoriesListModels();
            product.Categories = _context.Categories.OrderBy(c => c.Name).ToList();
            product.Product = _context.Products.Find(id);
           
            return View(product);
        }

        public IActionResult Delete(Product product )
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["message"] = $"{product.Name} deleted from Database.";
            return RedirectToAction("List");
        }

        
    }
}
