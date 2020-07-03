using DinosaursShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with order information.
    /// </summary>
    [Authorize]
    public class OrderController : Controller
    {
        private const string CheckoutCompleteAction = "CheckoutComplete";
        private const string CartEmptyAction = "CartEmpty";

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
            this.shoppingCart.ShoppingCartItems = this.shoppingCart.GetAllShoppingCartItems();

            if (this.shoppingCart.ShoppingCartItems.Count == 0)
            {
                return this.RedirectToAction(CartEmptyAction);
            }

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
            if (this.ModelState.IsValid)
            {
                this.orderRepository.CreateOrder(order);
                this.shoppingCart.ClearCart();
                return this.RedirectToAction(CheckoutCompleteAction);
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

        /// <summary>
        /// Display an information when cart is empty.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult CartEmpty()
        {
            this.ViewBag.CheckoutCompleteMessage = "Your cart is empty";

            return this.View();
        }
    }
}
