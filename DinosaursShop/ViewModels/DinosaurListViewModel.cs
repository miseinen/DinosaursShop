using System.Collections.Generic;
using DinosaursShop.Models;

namespace DinosaursShop.ViewModels
{
    /// <summary>
    /// Represents the data that displays on dinosaur list view.
    /// </summary>
    public class DinosaurListViewModel
    {
        /// <summary>
        /// Gets or sets an enumerable collection of dinosaurs.
        /// </summary>
        public IEnumerable<Dinosaur> Dinosaurs { get; set; }

        /// <summary>
        /// Gets or sets a current category.
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}
