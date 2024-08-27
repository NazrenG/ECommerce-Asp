using ECommerce.Business.Abstraction;
using ECommerce.Entity.Concretes;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _sessionService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, ICartSessionService sessionService, IProductService productService)
        {
            _cartService = cartService;
            _sessionService = sessionService;
            _productService = productService;
        }

        public async Task<IActionResult> AddToCart(int productId,int page,int category)
        {
            var item=await _productService.GetByIdAsync(productId);
            var cart = _sessionService.GetCart();
            _cartService.AddList(item, cart);
            _sessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your Product, {0} was added successfully to cart", item.ProductName));


            return RedirectToAction("Index", "Product",new {page=page,category=category});
        }
    }
}
