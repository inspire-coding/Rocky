using System.Collections.Generic;

namespace Rocky.Models.ViewModels
{
    public class ProductUserViewModel
    {
        public ProductUserViewModel()
        {
            Products = new List<Product>();
        }

        public ApplicationUser ApplicationUser { get; set; }
        public IList<Product> Products { get; set; }
    }
}
