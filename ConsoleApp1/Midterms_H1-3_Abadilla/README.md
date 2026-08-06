POS Web Application (Midterms H1-H3)
What I Built
An ASP.NET Core MVC Point of Sale app that connects my product catalog, shopping cart, and checkout system into one working project.

Code Breakdown
Models (Models/Domain/)
Product: Holds product info like name, price, description, and stock.
CartItem: Calculates subtotals for items picked by multiplying unit price and quantity.
ShoppingCart: Keeps track of active cart items and calculates the grand total.
Transaction: Stores finished order details including customer name, email, date, and items bought.
DTOs (Models/DTOs/)
AddToCartDto: Validates item ID and quantity when adding stuff to the cart.
UpdateCartItemDto: Validates quantity changes made inside the cart.
CheckoutDto: Makes sure customer name and email meet validation rules before processing an order.
Data & Services (Services/)
IPosRepository: Interface listing out methods for catalog loading, cart updates, and checkout.
InMemoryPosRepository: My repository class that holds data in memory so cart items and sales history don't reset between page loads.
Controllers (Controllers/)
CatalogController: Loads the product list and processes "Add to Cart" posts.
CartController: Renders the cart page, handles quantity updates, item deletions, and checkout posts.
TransactionsController: Pulls up past order history and individual receipts.
Front-End Views (Views/)
Catalog/Index: Product display with quick quantity inputs and add buttons.
Cart/Index: Table showing cart items, quantity controls, line totals, and the checkout form.
Transactions (Index & Details): History table for past orders and full receipt views.
Shared Files: Updated _Layout.cshtml with top navbar links and set up _ViewImports.cshtml namespaces.
Setup (Program.cs)
Registered IPosRepository as a singleton so data stays alive while navigating pages.
Changed default route to open directly to the product catalog on launch.