using Book_Store.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.ViewModels
{
    public class EditBookFormViewModel:BookFormViewModel
    {
        public int id {  get; set; }

        public string? CurrentCover { get; set; }


        [MaxFileSize(FileSettings.MaxFileSizeInByte)]
        [AllowedExtension(FileSettings.AllowExtenstions, ErrorMessage = "Only image files are allowed.")]
        public IFormFile? Cover { get; set; } = default!;
    }
}
