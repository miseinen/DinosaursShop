using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents the methods to work with the shopping cart information.
    /// </summary>
    public class ShoppingCart
    {
        private const string CartIdKey = "CartId";

        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        /// <param name="appDbContext">Application Db Context.</param>
        public ShoppingCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Gets or sets a shopping cart id.
        /// </summary>
        public string ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets a list of shopping cart items.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Expectation>")]
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        /// <summary>
        /// Get current shopping cart or create new cart.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        /// <returns>Shopping cart.</returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            AppDbContext context = services.GetService<AppDbContext>();
            string cartId = session.GetString(CartIdKey) ?? Guid.NewGuid().ToString();
            session.SetString(CartIdKey, cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        /// <summary>
        /// Add a shopping cart item to the shopping cart.
        /// </summary>
        /// <param name="dinosaur">Specimen of dinosaur.</param>
        /// <param name="amount">Amount of the dinosaurs.</param>
        public void AddToCart(Dinosaur dinosaur, int amount)
        {
            ShoppingCartItem shoppingCartItem = this.appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Dinosaur.DinosaurId == dinosaur.DinosaurId && s.ShoppingCartId == this.ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Dinosaur = dinosaur,
                    Amount = amount,
                };

                this.appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            this.appDbContext.SaveChanges();
        }

        /// <summary>
        /// Remove a shopping cart item from the shopping cart.
        /// </summary>
        /// <param name="dinosaur">Specimen of dinosaur.</param>
        /// <returns>Amount of the dinosaurs.</returns>
        public int RemoveFromCart(Dinosaur dinosaur)
        {
            ShoppingCartItem shoppingCartItem = this.appDbContext.ShoppingCartItems
                .SingleOrDefault(s => s.Dinosaur.DinosaurId == dinosaur.DinosaurId && s.ShoppingCartId == this.ShoppingCartId);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
            }
            else
            {
                this.appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            this.appDbContext.SaveChanges();

            return localAmount;
        }

        /// <summary>
        /// Get a collection of the shopping cart items.
        /// </summary>
        /// <returns>A collection of shopping cart items.</returns>
        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return this.ShoppingCartItems ?? (this.ShoppingCartItems = this.appDbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == this.ShoppingCartId)
                .Include(s => s.Dinosaur)
                .ToList());
        }

        /// <summary>
        /// Remove all shopping cart items.
        /// </summary>
        public void ClearCart()
        {
            IQueryable<ShoppingCartItem> cartItems = this.appDbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == this.ShoppingCartId);

            this.appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            this.appDbContext.SaveChanges();
        }

        /// <summary>
        /// Get the total cost of the shopping cart.
        /// </summary>
        /// <returns>Total cost.</returns>
        public decimal GetShopppingCartTotal()
        {
            var total = this.appDbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == this.ShoppingCartId)
                .Select(d => d.Dinosaur.Price * d.Amount)
                .Sum();

            return total;
        }
    }
}
