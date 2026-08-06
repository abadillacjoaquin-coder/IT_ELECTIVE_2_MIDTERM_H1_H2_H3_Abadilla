using Midterms_H1_3_Abadilla.Models.Domain;

namespace Midterms_H1_3_Abadilla.Services
{
    public interface IPosRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        ShoppingCart GetCart();
        void AddToCart(int productId, int quantity);
        void UpdateCartQuantity(int productId, int quantity);
        void RemoveFromCart(int productId);
        void ClearCart();
        Transaction ProcessCheckout(string customerName, string? customerEmail);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction? GetTransactionById(int id);
    }
}