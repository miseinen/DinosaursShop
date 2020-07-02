using DinosaursShop.Models;
using DinosaursShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Components
{
    /// <summary>
    /// Represents the logic for generating the shopping cart summary model.
    /// </summary>
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartSummary"/> class.
        /// </summary>
        /// <param name="shoppingCart">Shopping cart.</param>
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Invoke the logic for the shopping cart summary.
        /// </summary>
        /// <returns>View component result.</returns>
        public IViewComponentResult Invoke()
        {
            this.shoppingCart.ShoppingCartItems = this.shoppingCart.GetAllShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShopppingCartTotal(),
            };

            return this.View(shoppingCartViewModel);
        }
    }
}
