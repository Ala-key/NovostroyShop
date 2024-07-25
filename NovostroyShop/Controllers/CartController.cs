using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovostroyShop.Authentication;
using NovostroyShop.Models;
using NovostroyShop.Repositories;
using NovostroyShop.Services;

namespace NovostroyShop.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly IProductRepository productRepository;
        private readonly IRepository<Order> orderRepository;

        public CartController(CartService cartService, IProductRepository repository , IRepository<Order> orderRepository)
        {
            _cartService = cartService;
            productRepository = repository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Cart = _cartService.GetCart();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cart = _cartService.GetCart();
            if (cart.Items.Any())
            {
                order.OrderDetails = new List<OrderDetail>();

                foreach (var item in cart.Items)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        Product = await productRepository.GetById(item.Product.Id),
                        Quantity = item.Quantity
                    });
                }

                order.TotolSumm = order.OrderDetails.Sum(x => x.Product.Price);

                order.OrderDate = DateTime.Now;

                await orderRepository.Add(order);

                _cartService.SaveCart(new Cart()); // Очистка корзины

                return RedirectToAction("Completed", order);
            }

            ModelState.AddModelError("", "Корзина пуста, добавьте товары в корзину перед оформлением заказа.");
            return View();
        }

        public async Task<IActionResult> Completed(Order order)
        {
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await productRepository.GetById(productId);
            if (product != null)
            {
                var cart = _cartService.GetCart();
                cart.AddItem(product, 1);
                _cartService.SaveCart(cart);
            }
            return Content("");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _cartService.GetCart();
            cart.RemoveItem(productId);
            _cartService.SaveCart(cart);
            return RedirectToAction("Index");
        }

    }
}
