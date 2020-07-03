using System.Linq;
using DinosaursShop.Models;
using DinosaursShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with shopping cart information.
    /// </summary>
    public class ShoppingCartController : Controller
    {
        private const int OneSpecimen = 1;

        private const string DefaultActionName = "Index";

        private readonly IDinosaurRepository dinosaurRepository;
        private readonly ShoppingCart shoppingCart;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartController"/> class.
        /// </summary>
        /// <param name="dinosaurRepository">Dinosaur repository.</param>
        /// /// <param name="shoppingCart">Shopping cart.</param>
        public ShoppingCartController(IDinosaurRepository dinosaurRepository, ShoppingCart shoppingCart)
        {
            this.dinosaurRepository = dinosaurRepository;
            this.shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Display the shopping cart default information.
        /// </summary>
        /// <returns>View result.</returns>
        public ViewResult Index()
        {
            this.shoppingCart.ShoppingCartItems = this.shoppingCart.GetAllShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShopppingCartTotal(),
            };

            return this.View(shoppingCartViewModel);
        }

        /// <summary>
        /// Add the selected dinosaur to the cart.
        /// </summary>
        /// <param name="dinosaurId">Dinosaur id.</param>
        /// <returns>Redirect to action result.</returns>
        public RedirectToActionResult AddToShoppingCart(int dinosaurId)
        {
            Dinosaur selectedDinosaur = this.dinosaurRepository.GetAllDinosaurs
                .FirstOrDefault(s => s.DinosaurId == dinosaurId);

            if (selectedDinosaur != null)
            {
                this.shoppingCart.AddToCart(selectedDinosaur, OneSpecimen);
            }

            return this.RedirectToAction(DefaultActionName);
        }

        /// <summary>
        /// Remove the selected dinosaur from the cart.
        /// </summary>
        /// <param name="dinosaurId">Dinosaur id.</param>
        /// <returns>Redirect to action result.</returns>
        public RedirectToActionResult RemoveFromShoppingCart(int dinosaurId)
        {
            Dinosaur selectedDinosaur = this.dinosaurRepository.GetAllDinosaurs
                .FirstOrDefault(s => s.DinosaurId == dinosaurId);

            if (selectedDinosaur != null)
            {
                this.shoppingCart.RemoveFromCart(selectedDinosaur);
            }

            return this.RedirectToAction(DefaultActionName);
        }

        /// <summary>
        /// Remove all dinosaurs from the cart.
        /// </summary>
        /// <returns>Redirect to action result.</returns>
        public RedirectToActionResult ClearCart()
        {
            this.shoppingCart.ClearCart();

            return this.RedirectToAction(DefaultActionName);
        }
    }
}
