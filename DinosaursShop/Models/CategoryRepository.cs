using System.Collections.Generic;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display category information.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// /// <param name="appDbContext">Application Db context.</param>
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Gets an enumerable collection of all categories.
        /// </summary>
        public IEnumerable<Category> GetAllCategories => this.appDbContext.Categories;
    }
}
