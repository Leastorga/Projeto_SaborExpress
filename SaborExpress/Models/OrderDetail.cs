using System.ComponentModel.DataAnnotations.Schema;

namespace SaborExpress.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }           
        public int Quantity{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual Snack Snack{ get; set; }
        public int SnackId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
