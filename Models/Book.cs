using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    
        public class Book
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required.")]
            [MaxLength(250, ErrorMessage = "Title can't be longer than 250 characters.")]
            public string Title { get; set; }=string.Empty;

            [Required(ErrorMessage = "Price is required.")]
            [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000.")]
            public float Price { get; set; }

            [MaxLength(2500, ErrorMessage = "Description can't be longer than 3000 characters.")]
            public string Description { get; set; } = string.Empty;

            [Required(ErrorMessage = "Cover is required.")]
            public string Cover { get; set; } = string.Empty;

            [ForeignKey("Category")]
            public int? CategoryId { get; set; }

            public virtual Category? Category { get; set; }
        }

}
