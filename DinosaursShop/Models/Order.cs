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
        [StringLength(25)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a last name.
        /// </summary>
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets an address.
        /// </summary>
        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Street Address")]
        [StringLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a city.
        /// </summary>
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a sate.
        /// </summary>
        [Required(ErrorMessage = "Please enter your state")]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a zipcode.
        /// </summary>
        [Required(ErrorMessage = "Please enter your zip code")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        [Required(ErrorMessage = "Please enter your phone number")]
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
