namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display order information.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Create an order.
        /// </summary>
        /// <param name="order">Order.</param>
        void CreateOrder(Order order);
    }
}
