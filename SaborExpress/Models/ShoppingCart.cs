﻿using SaborExpress.Context;
using System.Security.Cryptography.X509Certificates;

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
        }

    }
}