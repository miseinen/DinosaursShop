namespace DinosaursShop.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides methods to display category information.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Gets an enumerable collection of all categories.
        /// </summary>
        IEnumerable<Category> GetAllCategories { get; }
    }
}
