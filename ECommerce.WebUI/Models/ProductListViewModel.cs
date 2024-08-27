using ECommerce.Entity.Models;

namespace ECommerce.WebUI.Models
{
	public class ProductListViewModel
	{
		public List<Product>? Product { get; set; }
		public int PageSize { get; set; }
		public int CurrentCategory { get; set; }
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }
		public string? OrderByName { get;  set; }
		public string? OrderByPrice{ get;  set; }
        public string? ControllerName { get; set; }
    }
}