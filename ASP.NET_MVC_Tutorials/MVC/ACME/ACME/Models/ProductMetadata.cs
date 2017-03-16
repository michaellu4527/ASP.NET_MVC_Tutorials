using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACME.Models
{
    public class ProductMetadata
    {
        [MetadataType(typeof(Product.Metadata))]
        public partial class Product
        {
            class Metadata
            {
                [Key]
                public System.Guid ProductId { get; set; }

                [Required(ErrorMessage = "This is a custom message")]   // Can create a custom error message
                [Display(Name="Product Name")]
                [StringLength(10)]  // Make sure product name is not more than 10 characters.
                public string Name { get; set; }

                [Required]
                [RegularExpression(@"^\$?\d+(\.d{2}))?$")]  // Regular expression for monetary types
                // [Range(0.01, 1000.0)]
                public decimal Price { get; set; }
                

            }
        }
    }
}