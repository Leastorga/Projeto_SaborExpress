using Microsoft.EntityFrameworkCore;
using SaborExpress.Context;

namespace SaborExpress.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<CartPurchaseItem> CartPurchaseItems { get; set; }

        public static ShoppingCart GetShopping(IServiceProvider services)
        {
            //Define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();
            //Obtem ou gera o Id do carrinho
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            // Retorna o carrinho com o contexto e o Id atribuído ou obtido
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId,
            };
        }
        public void AddToCart(Snack snack)
        {
            var cartPurchaseItem = _context.CartPurchaseItems.SingleOrDefault(s => s.Snack.SnackId == snack.SnackId && s.ShoppingCartId == ShoppingCartId);
            if (cartPurchaseItem == null)
            {
                cartPurchaseItem = new CartPurchaseItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Snack = snack,
                    Quantity = 1
                };
                _context.CartPurchaseItems.Add(cartPurchaseItem);
            }
            else
            {
                cartPurchaseItem.Quantity++;
            }
            _context.SaveChanges();

        }
        public int CartRemover(Snack snack)
        {
            var cartPurchaseItem = _context.CartPurchaseItems.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId && s.ShoppingCartId == ShoppingCartId);
            var localQuantity = 0;

            if(cartPurchaseItem != null)
            {
                if(cartPurchaseItem.Quantity > 1)
                {
                    cartPurchaseItem.Quantity--;
                    localQuantity = cartPurchaseItem.Quantity;
                }
                else
                {
                    _context.CartPurchaseItems.Remove(cartPurchaseItem);
                }
            }
            _context.SaveChanges();
            return localQuantity;
        }
        public List<CartPurchaseItem> GetCartPurchaseItems()
        {
            return CartPurchaseItems ?? (
                CartPurchaseItems = _context.CartPurchaseItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Snack)
                .ToList()); 
        }
        public void CleanCart()
        {
            var cartItems = _context.CartPurchaseItems
                .Where(cart =>
                cart.ShoppingCartId == ShoppingCartId);
            _context.CartPurchaseItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetTotalShoppingCart()
        {
            var Total = _context.CartPurchaseItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Snack.Price * c.Quantity).Sum();
            return Total;
        }
    }
}
