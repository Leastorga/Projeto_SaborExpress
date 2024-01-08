using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborExpress.Models
{
    [Table("Snacks")]
    public class Snack
    {
        [Key]
        public int SnackId { get; set; }
        [Required(ErrorMessage = "The name of the snack must be informed")]
        [Display(Name="Name of snack")]
        [StringLength(80, MinimumLength =10, ErrorMessage = "{0} must have at least {1} and at most {2}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description of the snack must be informed")]
        [Display(Name = "Description of snack")]
        [MinLength(20, ErrorMessage = "Description must have at least {1} characters")]
        [MaxLength(200, ErrorMessage = "Description can exceed {1} characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Detailed description of the snack must be provided")]
        [Display(Name = "Detailed description of the snack")]
        [MinLength(20, ErrorMessage = "Detailed description must be at least {1} characters")]
        [MaxLength(200, ErrorMessage = "Detailed description can exceed {1} characters")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Inform the price of the snack")]
        [Display(Name="Price")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = "The price must be between 1 and 999.99")]
        public decimal Price { get; set; }

        [Display(Name="Normal Image Path")]
        [StringLength(200, ErrorMessage ="The {0} must have of {1} characteres ")]
        public string ImageUrl { get; set; }

        [Display(Name = "Thumbnail Image Path")]
        [StringLength(200, ErrorMessage = "The {0} must have of {1} characteres ")]
        public string ThumbnailImageUrl { get; set; }

        [Display(Name="Favorite?")]
        public bool IsFavoriteSnack { get; set; }

        [Display(Name="Stock")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
