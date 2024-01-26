using SaborExpress.Context;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDispatched = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.CartPurchaseItems;

            foreach (var cartitem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = cartitem.Quantity,
                    SnackId = cartitem.Snack.SnackId,
                    OrderId = order.OrderId,
                    Price = cartitem.Snack.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }        
    }
}
