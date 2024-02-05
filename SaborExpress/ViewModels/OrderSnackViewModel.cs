using SaborExpress.Migrations;
using SaborExpress.Models;

namespace SaborExpress.ViewModels
{
    public class OrderSnackViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; } 
    }
}
