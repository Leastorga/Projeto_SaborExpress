using Microsoft.AspNetCore.Mvc;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List()
        {
            ViewData["Title"] = "All snacks";
            ViewData["Date"] = DateTime.Now;

            var snacks = _snackRepository.Snacks;

            var totalSnacks = snacks.Count();
            ViewBag.Total = "Total of snacks";
            ViewBag.TotalSnacks= totalSnacks;

            return View(snacks);
        }
    }
}

// Aqui estamos definindo o que será feito com os dados para mostrar pela a view