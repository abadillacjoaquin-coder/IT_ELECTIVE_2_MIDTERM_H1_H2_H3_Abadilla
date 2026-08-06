using System.ComponentModel.DataAnnotations;

namespace Midterms_H1_3_Abadilla.Models.DTOs
{
    public class AddToCartDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; } = 1;
    }
}