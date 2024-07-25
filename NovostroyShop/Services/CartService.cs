using NovostroyShop.Extensions;
using NovostroyShop.Models;

namespace NovostroyShop.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public Cart GetCart()
        {
            var cart = Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        public void SaveCart(Cart cart)
        {
            Session.SetObjectAsJson("Cart", cart);
        }
    }

}
