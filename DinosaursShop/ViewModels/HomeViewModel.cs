using System.Collections.Generic;
using DinosaursShop.Models;

namespace DinosaursShop.ViewModels
{
    /// <summary>
    /// Represents the data that displays on home controller view.
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Gets or sets an enumerable collection of dinosaurs.
        /// </summary>
        public IEnumerable<Dinosaur> DinosaurOnSale { get; set; }
    }
}
