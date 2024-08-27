using ECommerce.Entity.Concretes;

namespace ECommerce.WebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
