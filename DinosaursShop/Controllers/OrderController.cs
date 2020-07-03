using DinosaursShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with order information.
    /// </summary>
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderRepository">Order repository.</param>
        /// <param name="shoppingCart">Shopping cart.</param>
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Check an order information.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult Checkout()
        {
            return this.View();
        }

        /// <summary>
        /// Check an order information.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <returns>Action result.</returns>
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            this.shoppingCart.ShoppingCartItems = this.shoppingCart.GetAllShoppingCartItems();

            if (this.shoppingCart.ShoppingCartItems.Count == 0)
            {
                this.ModelState.AddModelError(" ", "Your cart is empty");
            }

            if (this.ModelState.IsValid)
            {
                this.orderRepository.CreateOrder(order);
                this.shoppingCart.ClearCart();
                return this.RedirectToAction("CheckOutComplete");
            }

            return this.View(order);
        }

        /// <summary>
        /// Display an information when checkout is complete.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult CheckoutComplete()
        {
            this.ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your dinosaurs.";

            return this.View();
        }
    }
}
