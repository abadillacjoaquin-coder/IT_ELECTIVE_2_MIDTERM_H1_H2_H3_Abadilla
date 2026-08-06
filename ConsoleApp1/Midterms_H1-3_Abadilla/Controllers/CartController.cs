using Microsoft.AspNetCore.Mvc;
using Midterms_H1_3_Abadilla.Models.DTOs;
using Midterms_H1_3_Abadilla.Services;

namespace Midterms_H1_3_Abadilla.Controllers
{
    public class CartController : Controller
    {
        private readonly IPosRepository _repo;

        public CartController(IPosRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var cart = _repo.GetCart();
            ViewBag.CheckoutDto = new CheckoutDto();
            return View(cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(UpdateCartItemDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateCartQuantity(dto.ProductId, dto.Quantity);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            _repo.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutDto dto)
        {
            var cart = _repo.GetCart();

            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                var transaction = _repo.ProcessCheckout(dto.CustomerName, dto.CustomerEmail);
                return RedirectToAction("Details", "Transactions", new { id = transaction.Id });
            }

            ViewBag.CheckoutDto = dto;
            return View("Index", cart);
        }
    }
}