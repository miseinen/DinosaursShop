using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories => new List<Category>
        {
            new Category{CategoryId=1, CategoryName="Hard Dinosaur", CategoryDescription="Beautiful and Strong Hard Dinosaur"},
            new Category{CategoryId=2, CategoryName="Light Dinosaur", CategoryDescription="Sweet and small Light Dinosaur"},
            new Category{CategoryId=3, CategoryName="Middle Dinosaur", CategoryDescription="Awesome and interesting Middle Dinosaur"},
        };
    }
}
