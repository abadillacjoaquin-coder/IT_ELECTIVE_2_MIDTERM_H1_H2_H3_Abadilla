using Microsoft.AspNetCore.Mvc;

namespace Midterms_H1_3_Abadilla.Services
{
    public class InMemoryPosRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
