using Book_Store.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.ViewModels
{
    public class BookFormViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(250, ErrorMessage = "Title can't be longer than 250 characters.")]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000.")]
        public float Price { get; set; }


        [MaxLength(2500, ErrorMessage = "Description can't be longer than 3000 characters.")]
        public string Description { get; set; } = string.Empty;



        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        public virtual Category? Category { get; set; }
  
    }
}
