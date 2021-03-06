using System.Collections.Generic;

namespace GuitarShop.Models
{
    public class CategoriesListModels
    {
        public Product Product { get; set; }
        public string SelectedId { get; set; }

        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }

        public string  CheckActiveCategory(string category) 
            {
                return  category == SelectedId ? "active" : "";
            } 

    }
}
