using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Data;
using Microsoft.EntityFrameworkCore;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    
    //[Route("Retails/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private  ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
           
            return View("List");

        }
        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.Category = _dbContext.Categories.OrderBy(m=>m.Name).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("List"); 
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Category = _dbContext.Categories.OrderBy(m => m.Name).ToList();
            var product = _dbContext.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Category = _dbContext.Categories.OrderBy(m => m.Name).ToList();
            var product = _dbContext.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List(string id = "All")
        {

            var pro = new CategoriesListModels
            {
                Categories = _dbContext.Categories.OrderBy(m => m.Name).ToList(),
                SelectedId = id,
                Products = _dbContext.Products.Include(m => m.Category).OrderBy(m => m.ProductId).ToList()

            };
            return View(pro);
          
           //ViewBag.Category = _dbContext.Categories.OrderBy(m => m.Name).ToList();
           // ViewBag.SelectId = id;
           // var product = _dbContext.Products.Include(m=>m.Category).OrderBy(m => m.ProductId).ToList();
                
               //return View(product);

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            //Console.WriteLine(ProductId
            var product = _dbContext.Products.Find(id);
            ViewBag.category = _dbContext.Categories.Find(product.CategoryId);

            return View(product);
        }


        [NonAction]
        public string GetSlug(string name)
        {
           return name.Replace(' ', '-').ToLower();
        }
    }
}
