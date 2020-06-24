using System.Collections.Generic;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display dinosaur information.
    /// </summary>
    public interface IDinosaurRepository
    {
        /// <summary>
        /// Gets an enumerable collection of all dinosaurs.
        /// </summary>
        IEnumerable<Dinosaur> GetAllDinosaurs { get; }

        /// <summary>
        /// Gets an enumerable collection of dinosaurs which are on sale.
        /// </summary>
        IEnumerable<Dinosaur> GetDinosaursOnSale { get; }

        /// <summary>
        /// Get information about dinosaur by id.
        /// </summary>
        /// <param name="dinosaurId">Dinosaur id.</param>
        /// <returns>Dinosaur by id.</returns>
        Dinosaur GetDinosaurById(int dinosaurId);
    }
}
