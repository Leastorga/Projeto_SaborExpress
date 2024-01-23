using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(x => x.SnackId);
                currentCategory = "All snacks";
            }
            else
            {
            
                if (string.Equals("Normal", category, StringComparison.OrdinalIgnoreCase))
                {
                    snacks = _snackRepository.Snacks.Where(x => x.Category.CategoryName.Equals("Normal"))
                        .OrderBy(x => x.Name);
                }
                else
                {
                    snacks = _snackRepository.Snacks.Where(x => x.Category.CategoryName.Equals("Natural"))
                        .OrderBy(x => x.Name);
                }
                currentCategory = category;
            }
            var snacksListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            };
            return View(snacksListViewModel);
        }
    }
}

// Aqui estamos definindo o que será feito com os dados para mostrar pela a view