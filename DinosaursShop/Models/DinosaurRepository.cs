using System;
using System.Collections.Generic;
using System.Linq;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display dinosaurs information.
    /// </summary>
    public class DinosaurRepository : IDinosaurRepository
    {
        private readonly ICategoryRepository categoryRepository = new CategoryRepository();

        /// <summary>
        /// Gets an enumerable collection of all dinosaurs.
        /// </summary>
        public IEnumerable<Dinosaur> GetAllDinosaurs => new List<Dinosaur>
        {
            new Dinosaur
            {
                DinosaurId = 1, Name = "Allosaurus", Price = 1200M,
                Description = "Fast", Category = this.categoryRepository.GetAllCategories.ToList()[0],
                ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/Allosaurus_Juvenile_Reconstruction.jpg/1024px-Allosaurus_Juvenile_Reconstruction.jpg"),
                ImageThumbnailUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/Allosaurus_Juvenile_Reconstruction.jpg/220px-Allosaurus_Juvenile_Reconstruction.jpg"),
                IsInStock = true, IsOnSale = false,
            },
            new Dinosaur
            {
                DinosaurId = 2, Name = "Brachiosaurus", Price = 1500M,
                Description = "Big", Category = this.categoryRepository.GetAllCategories.ToList()[2],
                ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/c/cf/Brachiosaurus_NT_new.jpg"),
                ImageThumbnailUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Brachiosaurus_NT_new.jpg/220px-Brachiosaurus_NT_new.jpg"),
                IsInStock = true, IsOnSale = false,
            },
            new Dinosaur
            {
                DinosaurId = 3, Name = "Velociraptor", Price = 500M,
                Description = "Cute", Category = this.categoryRepository.GetAllCategories.ToList()[1],
                ImageUrl = new Uri("https://en.wikipedia.org/wiki/Velociraptor#/media/File:Velociraptor_Restoration.png"),
                ImageThumbnailUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Velociraptor_Restoration.png/220px-Velociraptor_Restoration.png"),
                IsInStock = true, IsOnSale = false,
            },
        };

        /// <summary>
        /// Gets an enumerable collection of dinosaurs which are on sale.
        /// </summary>
        public IEnumerable<Dinosaur> GetDinosaursOnSale => throw new NotImplementedException();

        /// <summary>
        /// Get information about dinosaur by id.
        /// </summary>
        /// <param name="dinosaurId">Dinosaur id.</param>
        /// <returns>Dinosaur by id.</returns>
        public Dinosaur GetDinosaurById(int dinosaurId)
        {
            return this.GetAllDinosaurs.FirstOrDefault(d => d.DinosaurId == dinosaurId);
        }
    }
}
