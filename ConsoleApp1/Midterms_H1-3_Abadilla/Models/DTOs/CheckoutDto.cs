using System.ComponentModel.DataAnnotations;

namespace Midterms_H1_3_Abadilla.Models.DTOs
{
    public class CheckoutDto
    {
        [Required(ErrorMessage = "Customer name is required for checkout.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer name must be between 2 and 100 characters.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Customer Email (Optional)")]
        public string? CustomerEmail { get; set; }
    }
}