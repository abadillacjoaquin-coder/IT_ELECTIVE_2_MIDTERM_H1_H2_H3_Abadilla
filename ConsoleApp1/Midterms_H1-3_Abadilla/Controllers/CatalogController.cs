using Microsoft.AspNetCore.Mvc;

namespace Midterms_H1_3_Abadilla.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
