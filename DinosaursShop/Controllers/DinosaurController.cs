using DinosaursShop.Models;
using DinosaursShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with dinosaurs information.
    /// </summary>
    public class DinosaurController : Controller
    {
        private readonly IDinosaurRepository dinosaurRepository;
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DinosaurController"/> class.
        /// </summary>
        /// <param name="dinosaurRepository">Dinosaur repository.</param>
        /// <param name="categoryRepository">Category repository.</param>
        public DinosaurController(IDinosaurRepository dinosaurRepository, ICategoryRepository categoryRepository)
        {
            this.dinosaurRepository = dinosaurRepository;
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Display the collection of dinosaurs.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult List()
        {
            DinosaurListViewModel dinosaurListViewModel = new DinosaurListViewModel();
            dinosaurListViewModel.Dinosaurs = this.dinosaurRepository.GetAllDinosaurs;
            dinosaurListViewModel.CurrentCategory = "Bestsellers";
            return this.View(dinosaurListViewModel);
        }

        /// <summary>
        /// Display ditails about the selected dinosaur.
        /// </summary>
        /// /// <param name="id">Dinosaur ID.</param>
        /// <returns>Action result.</returns>
        public IActionResult Details(int id)
        {
            var dinosaur = this.dinosaurRepository.GetDinosaurById(id);

            if (dinosaur == null)
            {
                return this.NotFound();
            }

            return this.View(dinosaur);
        }
    }
}
