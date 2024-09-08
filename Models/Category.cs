using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }=string.Empty;

        public ICollection<Book>? Books { get; set; }

    }
}
