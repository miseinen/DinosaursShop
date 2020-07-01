using DinosaursShop.Models;
using DinosaursShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with home information.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IDinosaurRepository dinosaurRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dinosaurRepository">Dinosaur repository.</param>
        public HomeController(IDinosaurRepository dinosaurRepository)
        {
            this.dinosaurRepository = dinosaurRepository;
        }

        /// <summary>
        /// Display the default information.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                DinosaurOnSale = this.dinosaurRepository.GetDinosaursOnSale,
            };

            return this.View(homeViewModel);
        }
    }
}
