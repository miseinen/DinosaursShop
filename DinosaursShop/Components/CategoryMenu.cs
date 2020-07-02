using System.Linq;
using DinosaursShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Components
{
    /// <summary>
    /// Represents the logic for generating the category menu model.
    /// </summary>
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMenu"/> class.
        /// </summary>
        /// <param name="categoryRepository">Category repository.</param>
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Invoke the logic for the category menu.
        /// </summary>
        /// <returns>View component result.</returns>
        public IViewComponentResult Invoke()
        {
            var categories = this.categoryRepository.GetAllCategories.OrderBy(s => s.CategoryName);

            return this.View(categories);
        }
    }
}
