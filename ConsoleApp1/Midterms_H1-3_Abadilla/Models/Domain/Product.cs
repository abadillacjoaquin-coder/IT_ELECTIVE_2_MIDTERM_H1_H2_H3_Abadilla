using Microsoft.AspNetCore.Mvc;

namespace Midterms_H1_3_Abadilla.Models.Domain
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
