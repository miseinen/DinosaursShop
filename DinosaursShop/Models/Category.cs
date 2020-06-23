namespace DinosaursShop.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the category model properties.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets the list of dinosaurs.
        /// </summary>
        public List<Dinosaur> Dinosaurs { get; }
    }
}
