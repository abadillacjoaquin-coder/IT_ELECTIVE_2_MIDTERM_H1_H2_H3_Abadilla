using Microsoft.AspNetCore.Mvc;
using Midterms_H1_3_Abadilla.Services;

namespace Midterms_H1_3_Abadilla.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IPosRepository _repo;

        public TransactionsController(IPosRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var transactions = _repo.GetAllTransactions();
            return View(transactions);
        }

        public IActionResult Details(int id)
        {
            var transaction = _repo.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }
    }
}