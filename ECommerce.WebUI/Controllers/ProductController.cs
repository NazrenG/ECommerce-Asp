using ECommerce.Business.Abstraction;
using ECommerce.Entity.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> Index(int category = 0, int page = 1, string orderByName = "",
			string orderByPrice = "",string controllerName="product")
		{
			var list = await _productService.GetAllByCategoryAsync(category);
			int pageSize = 10;

			if (orderByName == "asc")
				list = list.OrderBy(p => p.ProductName).ToList();
			else if (orderByName == "desc")
				list = list.OrderByDescending(p => p.ProductName).ToList();


			else if (orderByPrice == "asc")
				list = list.OrderBy(p => p.UnitPrice).ToList();
			else if (orderByPrice == "desc")
				list = list.OrderByDescending(p => p.UnitPrice).ToList();


			List<Product> products = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();


			var productList = new ProductListViewModel
			{
				Product = list.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
				PageSize = pageSize,
				CurrentCategory = category,
				CurrentPage = page,
				PageCount = (int)Math.Ceiling(list.Count / (double)pageSize),
				OrderByName = orderByName,
				OrderByPrice = orderByPrice,
				ControllerName=controllerName
			};

			return View(productList);
		} 


	}
}
