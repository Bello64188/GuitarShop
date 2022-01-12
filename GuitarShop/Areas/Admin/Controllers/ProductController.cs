using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            return Content("Admin products list id is " +id);
        }

        public IActionResult Add()
        {
            return Content("Admin product Add ");
        }

        public IActionResult Update(int id)
        {
            return Content("Admin product update id is " + id);
        }

        public IActionResult Delete(int id)
        {
            return Content("Admin product Delete id is " + id);
        }


    }
}
