using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalItemsOrder = 0;
            decimal totalOrderPrice = 0.0m;

            // Obtem os itens do carrinho de compra do cliente
            List<CartPurchaseItem> items = _shoppingCart.GetCartPurchaseItems();
            _shoppingCart.CartPurchaseItems = items;

            //Verifica se existem itens de pedido
            if (_shoppingCart.CartPurchaseItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, how about adding a snack...");
            }
            // Calcular o total de items e o total do pedido
            foreach (var item in items)
            {
                totalItemsOrder += item.Quantity;
                totalOrderPrice += (item.Snack.Price * item.Quantity);
            }

            //Atribui os valores obtidos ao pedido
            order.TotalItemsOrder = totalItemsOrder;
            order.TotalOrder = totalOrderPrice;

            //Valida os dados pedido
            if (ModelState.IsValid)
            {
                //Cria o pedido e os detalhes
                _orderRepository.CreateOrder(order);

                //Define mensagens ao cliente
                ViewBag.CheckoutCompleteMessage = "Thank you for your order :)";
                ViewBag.TotalOrder = _shoppingCart.GetTotalShoppingCart();

                //Limpa o carrinho do cliente
                _shoppingCart.CleanCart();

                //Exibe a view com dados do cliente e do pedido

                return View("~/Views/Order/CheckoutComplete.cshtml", order);
            }
            return View(order);
        }
    }
}
