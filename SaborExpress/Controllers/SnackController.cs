using Microsoft.AspNetCore.Mvc;
using SaborExpress.Repositories.Interfaces;
using SaborExpress.ViewModels;

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
            //var snacks = _snackRepository.Snacks;
            //return View(snacks);
            var snacksListViewModel = new SnackListViewModel();
            snacksListViewModel.Snacks = _snackRepository.Snacks;
            snacksListViewModel.CurrentCategory = "Current Category"; 
            return View(snacksListViewModel);
        }
    }
}

// Aqui estamos definindo o que será feito com os dados para mostrar pela a view