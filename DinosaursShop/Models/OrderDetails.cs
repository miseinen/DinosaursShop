using System.ComponentModel.DataAnnotations;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents the order details properties.
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Gets or sets an order detail id.
        /// </summary>
        [Key]
        public int OrderDetailId { get; set; }

        /// <summary>
        /// Gets or sets an order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets an id of ordered dinosaur.
        /// </summary>
        public int DinosaurId { get; set; }

        /// <summary>
        /// Gets or sets the ordered dinosaur.
        /// </summary>
        public Dinosaur Dinosaur { get; set; }

        /// <summary>
        /// Gets or sets the ordered amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the ordered price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets an order.
        /// </summary>
        public Order Order { get; set; }
    }
}
