using SaborExpress.Models;

namespace SaborExpress.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
