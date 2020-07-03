using Microsoft.AspNetCore.Mvc;

namespace DinosaursShop.Controllers
{
    /// <summary>
    /// Represents methods to work with contact data.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Display the default information.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
