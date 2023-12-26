using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborExpress.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters")]
        [Required(ErrorMessage = "Enter the name of the category")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }
        [StringLength(200, ErrorMessage = "Maximum length is 100 characters")]
        [Required(ErrorMessage = "Enter the description of the category")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Snack> Snacks { get; set; }
    }
}
