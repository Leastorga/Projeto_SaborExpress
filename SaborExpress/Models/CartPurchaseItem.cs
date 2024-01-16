using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborExpress.Models
{
    [Table("CartPurchaseItem")]
    public class CartPurchaseItem
    {
        public int Id { get; set; }
        public Snack Snack { get; set; }
        public int Quantity {  get; set; }
        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
