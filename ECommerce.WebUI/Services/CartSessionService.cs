using ECommerce.Entity.Concretes;
using ECommerce.WebUI.Extentions;

namespace ECommerce.WebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        IHttpContextAccessor context { get; set; }//program.cs de qeydiyyatdan kecirilmelidir
        public CartSessionService(IHttpContextAccessor context)
        {
            this.context = context;
        }

        public Cart GetCart()
        {
            Cart checkCart= context.HttpContext.Session.GetObject<Cart>("cart");
            if (checkCart == null)
            {
                context.HttpContext.Session.SetObject("cart",new Cart());
                checkCart= context.HttpContext.Session.GetObject<Cart>("cart");

            }
            return checkCart;
        }

        public void SetCart(Cart cart)
        {
           context.HttpContext.Session.SetObject("cart",cart);
        }
    }
}
