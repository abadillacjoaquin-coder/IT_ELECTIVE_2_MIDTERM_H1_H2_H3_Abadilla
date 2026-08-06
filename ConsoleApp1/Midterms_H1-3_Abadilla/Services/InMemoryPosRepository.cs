using Midterms_H1_3_Abadilla.Models.Domain;

namespace Midterms_H1_3_Abadilla.Services
{
    public class InMemoryPosRepository : IPosRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Wireless Mouse", Description = "Ergonomic optical mouse", Price = 25.00m, Stock = 50 },
            new Product { Id = 2, Name = "Mechanical Keyboard", Description = "RGB Backlit mechanical keyboard", Price = 75.50m, Stock = 30 },
            new Product { Id = 3, Name = "27-inch Monitor", Description = "4K UHD IPS display", Price = 299.99m, Stock = 15 },
            new Product { Id = 4, Name = "USB-C Hub", Description = "7-in-1 multi-port adapter", Price = 45.00m, Stock = 40 }
        };

        private readonly ShoppingCart _cart = new();
        private readonly List<Transaction> _transactions = new();
        private int _nextTransactionId = 1001;

        public IEnumerable<Product> GetAllProducts() => _products;

        public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public ShoppingCart GetCart() => _cart;

        public void AddToCart(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product == null) return;

            var item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                _cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = quantity
                });
            }
        }

        public void UpdateCartQuantity(int productId, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                    _cart.Items.Remove(item);
                else
                    item.Quantity = quantity;
            }
        }

        public void RemoveFromCart(int productId)
        {
            _cart.Items.RemoveAll(i => i.ProductId == productId);
        }

        public void ClearCart()
        {
            _cart.Items.Clear();
        }

        public Transaction ProcessCheckout(string customerName, string? customerEmail)
        {
            var transaction = new Transaction
            {
                Id = _nextTransactionId++,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                TransactionDate = DateTime.Now,
                TotalAmount = _cart.GrandTotal,
                Items = new List<CartItem>(_cart.Items)
            };

            _transactions.Add(transaction);
            ClearCart();
            return transaction;
        }

        public IEnumerable<Transaction> GetAllTransactions() => _transactions.OrderByDescending(t => t.TransactionDate);

        public Transaction? GetTransactionById(int id) => _transactions.FirstOrDefault(t => t.Id == id);
    }
}