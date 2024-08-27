using ECommerce.Business.Abstraction;
using ECommerce.Entity.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerce.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
       ICategoryService categoryService;

		public CategoryListViewComponent(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		public ViewViewComponentResult Invoke()
        {
            var param = HttpContext.Request.Query["category"];
            var category = int.TryParse(param, out var categoryId);
            var categories = new CategoryViewModel { 
                Categories= categoryService.GetAllCategoryAsync().Result,
                CurrentCategory=category? categoryId:0
            };
            return View(categories);
        }
    }
}
