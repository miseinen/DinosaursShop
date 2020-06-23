namespace DinosaursShop.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides methods to display category information.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        /// <summary>
        /// Gets an enumerable collection of all categories.
        /// </summary>
        public IEnumerable<Category> GetAllCategories => new List<Category>
        {
            new Category { CategoryId = 3, CategoryName = "Middle Dinosaur", CategoryDescription = "Awesome and interesting Middle Dinosaur" },
            new Category { CategoryId = 1, CategoryName = "Hard Dinosaur", CategoryDescription = "Beautiful and Strong Hard Dinosaur" },
            new Category { CategoryId = 2, CategoryName = "Light Dinosaur", CategoryDescription = "Sweet and small Light Dinosaur" },
        };
    }
}
