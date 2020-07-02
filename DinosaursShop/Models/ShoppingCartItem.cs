namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents shopping cart item properties.
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// Gets or sets a shopping cart item id.
        /// </summary>
        public int ShoppingCartItemId { get; set; }

        /// <summary>
        /// Gets or sets a shopping cart id.
        /// </summary>
        public string ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets a dinosaur.
        /// </summary>
        public Dinosaur Dinosaur { get; set; }

        /// <summary>
        /// Gets or sets amount of dinosaurs.
        /// </summary>
        public int Amount { get; set; }
    }
}
