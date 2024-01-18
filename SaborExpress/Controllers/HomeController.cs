using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;
using SaborExpress.ViewModels;
using System.Diagnostics;

namespace SaborExpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public HomeController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult Index() // Está retornando o view ao acessar a página, isso se deve a interface IActionResult
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteSnack = _snackRepository.FavoriteSnack
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
