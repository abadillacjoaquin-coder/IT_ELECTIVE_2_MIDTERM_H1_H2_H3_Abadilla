using Microsoft.AspNetCore.Mvc;

namespace Midterms_H1_3_Abadilla.Models.Domain
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal GrandTotal => Items.Sum(item => item.LineTotal);
    }
}
