using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using SaborExpress.ViewModels;

namespace SaborExpress.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        //Posso dizer que sempre que eu quiser criar um componente ele só pode ser invocado se utilizarmos o Invoke.
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetCartPurchaseItems();

            var items = new List<CartPurchaseItem>() {
                new CartPurchaseItem(),
                new CartPurchaseItem()
            };

            _shoppingCart.CartPurchaseItems = items;
            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                TotalShoppingCart = _shoppingCart.GetTotalShoppingCart()
            };
            return View(shoppingCartVM);
        }
    }
}
