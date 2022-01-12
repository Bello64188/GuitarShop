using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarShop.Models
{
    public class Product
    {       
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public string Slug() => Name.Replace(' ','-');

    }
}
