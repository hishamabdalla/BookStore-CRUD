using System.ComponentModel.DataAnnotations;

namespace Book_Store.Attributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int _MaxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this._MaxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                
                if (file.Length> _MaxFileSize)
                {
                    return new ValidationResult(ErrorMessage ?? $"File size should not exceed {FileSettings.MaxFileSizeInMB} MB.");
                }
            }
            return ValidationResult.Success;

        }
    }
}
