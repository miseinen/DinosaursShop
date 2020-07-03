using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display order information.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="appDbContext">Application Db context.</param>
        /// <param name="shoppingCart">Shopping cart.</param>
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Create an order.
        /// </summary>
        /// <param name="order">Order.</param>
        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = this.shoppingCart.GetShopppingCartTotal();

            this.appDbContext.Orders.Add(order);
            this.appDbContext.SaveChanges();

            List<ShoppingCartItem> shoppingCartItems = this.shoppingCart.GetAllShoppingCartItems();

            foreach (var item in shoppingCartItems)
            {
                var orderDetails = new OrderDetails
                {
                    OrderId = order.OrderId,
                    DinosaurId = item.Dinosaur.DinosaurId,
                    Amount = item.Amount,
                    Price = item.Dinosaur.Price,
                };

                this.appDbContext.OrderDetails.Add(orderDetails);
            }

            this.appDbContext.SaveChanges();
        }
    }
}
