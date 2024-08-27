using ECommerce.Entity.Models;
using ECommerce.WebUI.Models;

namespace ECommerce.WebUI
{
    public class CategoryAndProductViewModel
    {
        public ProductListViewModel? Products { get; set; }
        public CategoryViewModel? Categories { get; set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }   
    }
}