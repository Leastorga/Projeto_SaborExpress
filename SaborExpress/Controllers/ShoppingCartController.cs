using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;
using SaborExpress.ViewModels;

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
            var items = _shoppingCart.GetCartPurchaseItems();
            _shoppingCart.CartPurchaseItems = items;

            var shoppingCartVM = new ShoppingCartViewModel {
                ShoppingCart = _shoppingCart,
                TotalShoppingCart = _shoppingCart.GetTotalShoppingCart()    
            };
            return View(shoppingCartVM);
        }

        public IActionResult AddItemToShoppingcart(int snackId)
        {
            var selectedItem = _snackRepository.Snacks.FirstOrDefault(p => p.SnackId == snackId);
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToShoppingcart(int snackId)
        {
            var selectedItem = _snackRepository.Snacks.FirstOrDefault(p => p.SnackId == snackId);
            if (selectedItem != null)
            {
                _shoppingCart.CartRemover(selectedItem);
            }
            return RedirectToAction("Index");
        }


    }
}
