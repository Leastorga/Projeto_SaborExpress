using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborExpress.Models
{
    public class Order
    {
        public int OrderId {  get; set; }

        [Required(ErrorMessage ="Provide your name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide your lastname")]
        [StringLength(50)]
        public string LastName {  get; set; }

        [Required(ErrorMessage = "Provide your Address")]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address01 {  get; set; }

        [StringLength(100)]
        [Display(Name = "Complement")]
        public string Address02 { get; set; }

        [Required(ErrorMessage = "Provide your CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        [StringLength(10)]
        public string State { get; set;}

        [StringLength(50)]
        public string City { get; set;}

        [Required(ErrorMessage = "Provide your telephone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Provide your Email Address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email does not have a correct format")]
        public string Email { get; set;}

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Order")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Order Items")]
        public int TotalItemsOrder { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderDispatched { get; set; }

        [Display(Name = "Order shipping date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDeliveredTo { get; set; }
        //public List<OrderDetail> OrderItems { get; set; }  
    }
}
