using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnackRepository snackRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
