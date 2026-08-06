namespace Midterms_H1_3_Abadilla.Models.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}