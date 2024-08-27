using ECommerce.Business.Abstraction;
using ECommerce.Entity.Models;
using ECommerce.WebUI.Models;
using ECommerce.WebUI.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderDetailService _orderDetailService;

        public AdminController(IProductService productService, ICategoryService categoryService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderDetailService = orderDetailService;
        }


        public async Task<IActionResult> Index(int category = 0, int page = 1,
            string orderByName = "", string orderByPrice = "", string controllerName = "admin")
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
                ControllerName = controllerName
            };
            var categoryList = new CategoryViewModel
            {
                Categories = await _categoryService.GetAllCategoryAsync(),
                CurrentCategory = category,
            };

            var productAndCategoryList = new CategoryAndProductViewModel
            {
                Products = productList,
                Categories = categoryList,
                Category = new Category(),
                Product = new Product(),
            };


            return View(productAndCategoryList);
        }
        //Add and Delete operation for Category
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(category);
                TempData.Add("message", "Category created successfully!");

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Remove(int id)
        {  await _productService.DeleteForCategoryId(id);
            await _orderDetailService.DeleteForProductId(id);
           
            await _categoryService.DeleteAsync(id);
            TempData.Add("message", "Category removed successfully!");


            return RedirectToAction("Index");
        }

        //For Product 
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            var categories = await _categoryService.GetAllCategoryAsync();

            var list = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            ViewBag.CategoryList = new SelectList(list, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                TempData["SuccessMessage"] = "Product removed successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveProduct(int id, int page, int category, string orderByName, string orderByPrice)
        {

            await _orderDetailService.DeleteForProductId(id);
            await _productService.DeleteAsync(id);
            TempData.Add("message", "Product removed successfully!");
            return RedirectToAction("Index", new { page = page, category = category, orderByName = orderByName, orderByPrice = orderByPrice });

        }
    }
}
