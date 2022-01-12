using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Data;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    public class HomeController : Controller
    {
        private  ApplicationDbContext _applicationDb;

        public HomeController(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        //[Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
           // ViewData["Title"] = "Personal  Data";
            ViewData["Name"] = "Bello Azeez";
            ViewData["Age"] = 22.66;
            ViewData["Address"] = "Sobi Road Ilorin";
            
            return View();

        }
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }


    }
}
