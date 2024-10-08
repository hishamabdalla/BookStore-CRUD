﻿using Book_Store.Attributes;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.ViewModels
{
    public class CreateBookFormViewModel:BookFormViewModel
    {
        
        [MaxFileSize(FileSettings.MaxFileSizeInByte)]
        [AllowedExtension(FileSettings.AllowExtenstions, ErrorMessage = "Only image files are allowed.")]
        [Required(ErrorMessage = "Cover is required.")]
        public IFormFile Cover { get; set; } = default!;
    }
}
