namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents the dinosaur model properties.
    /// </summary>
    public class Dinosaur
    {
        /// <summary>
        /// Gets or sets the dinosaur id.
        /// </summary>
        public int DinosaurId { get; set; }

        /// <summary>
        /// Gets or sets the dinosaur name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dinosaur description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the dinosaur price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the image thumbnail url.
        /// </summary>
        public string ImageThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dinosaur is on sale.
        /// </summary>
        public bool IsOnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dinosaur is in stock.
        /// </summary>
        public bool IsInStock { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public Category Category { get; set; }
    }
}
