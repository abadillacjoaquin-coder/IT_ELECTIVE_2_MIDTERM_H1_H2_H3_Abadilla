using System.ComponentModel.DataAnnotations;

namespace Midterms_H1_3_Abadilla.Models.DTOs
{
    public class UpdateCartItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}