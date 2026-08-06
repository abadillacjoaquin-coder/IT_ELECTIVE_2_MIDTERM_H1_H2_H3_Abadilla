using Microsoft.AspNetCore.Mvc;
using Midterms_H1_3_Abadilla.Models.DTOs;
using Midterms_H1_3_Abadilla.Services;

namespace Midterms_H1_3_Abadilla.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IPosRepository _repo;

        public CatalogController(IPosRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.AddToCart(dto.ProductId, dto.Quantity);
                TempData["SuccessMessage"] = "Item added to cart!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}