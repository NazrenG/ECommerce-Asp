using ECommerce.Entity.Models;

namespace ECommerce.WebUI.Models
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get;  set; }
    }
}