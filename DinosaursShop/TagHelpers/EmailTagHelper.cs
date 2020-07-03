using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DinosaursShop.TagHelpers
{
    /// <summary>
    /// Represents server-side code to participate in creating and rendering HTML elements in Razor files for contact email.
    /// </summary>
    public class EmailTagHelper : TagHelper
    {
        /// <summary>
        /// Gets or sets an address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a link text.
        /// </summary>
        public string LinkText { get; set; }

        /// <summary>
        /// Process an email contact data.
        /// </summary>
        /// <param name="context">Tag helper context.</param>
        /// <param name="output">Tag helper output.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            base.Process(context, output);

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + this.Address);
            output.Content.SetContent(this.LinkText);
        }
    }
}
