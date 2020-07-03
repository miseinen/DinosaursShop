using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents the order model properties.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets an order id.
        /// </summary>
        [BindNever]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets a first name.
        /// </summary>
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please use only Latin letters")]
        [StringLength(25)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a last name.
        /// </summary>
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please use only Latin letters")]
        [StringLength(25, ErrorMessage = "Please use up to 25 letters")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets an address.
        /// </summary>
        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Street Address")]
        [StringLength(100, ErrorMessage = "Please use up to 100 letters")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a city.
        /// </summary>
        [Required(ErrorMessage = "Please enter your city")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please use only Latin letters")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a sate.
        /// </summary>
        [Required(ErrorMessage = "Please enter your state")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please use only Latin letters")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Please use up to 2 letters")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a zipcode.
        /// </summary>
        [Required(ErrorMessage = "Please enter your zip code")]
        [RegularExpression(@"^[1-9]*$", ErrorMessage = "Please use only digits")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Please use up to 5 letters")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^[+]?\d{3}[(]?\d{2}[)]?\d{3}[- .]?\d{4}$", ErrorMessage = "Please enter your phone number")]
        [StringLength(20, MinimumLength = 12, ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets an enumerable collection of order details.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Expectation>")]
        public List<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the total number of orders.
        /// </summary>
        [BindNever]
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Gets or sets the date when an order was placed.
        /// </summary>
        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
