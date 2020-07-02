using DinosaursShop.Models;

namespace DinosaursShop.ViewModels
{
    /// <summary>
    /// Represents the data that displays on shopping cart view.
    /// </summary>
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// Gets or sets a shopping cart.
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart total.
        /// </summary>
        public decimal ShoppingCartTotal { get; set; }
    }
}
