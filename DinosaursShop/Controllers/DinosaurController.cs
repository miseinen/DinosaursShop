namespace DinosaursShop.Controllers
{
    using DinosaursShop.Models;
    using Microsoft.AspNetCore.Mvc;

    public class DinosaurController : Controller
    {
        private readonly IDinosaurRepository dinosaurRepository;
        private readonly ICategoryRepository categoryRepository;

        public DinosaurController(IDinosaurRepository dinosaurRepository, ICategoryRepository categoryRepository)
        {
            this.dinosaurRepository = dinosaurRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            return this.View(this.dinosaurRepository.GetAllDinosaurs);
        }
    }
}
