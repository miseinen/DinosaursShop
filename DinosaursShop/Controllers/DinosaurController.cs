using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="category">Dinosaur category.</param>
        /// <returns>View result.</returns>
        public ViewResult List(string category)
        {
            string selectedCategory;
            IEnumerable<Dinosaur> dinosaurs;

            if (string.IsNullOrEmpty(category))
            {
                dinosaurs = this.dinosaurRepository.GetAllDinosaurs.OrderBy(c => c.DinosaurId);
                selectedCategory = "All Dinosaurs";
            }
            else
            {
                var stringComparison = StringComparison.InvariantCulture;
                dinosaurs = this.dinosaurRepository.GetAllDinosaurs
                    .Where(c => string.Equals(c.Category.CategoryName, category, stringComparison));

                selectedCategory = this.categoryRepository.GetAllCategories
                    .FirstOrDefault(c => string.Equals(c.CategoryName, category, stringComparison))?.CategoryName;
            }

            var dinosaurListViewModel = new DinosaurListViewModel
            {
                Dinosaurs = dinosaurs,
                CurrentCategory = selectedCategory,
            };

            return this.View(dinosaurListViewModel);
        }

        /// <summary>
        /// Display ditails about the selected dinosaur.
        /// </summary>
        /// <param name="id">Dinosaur ID.</param>
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
