using System.ComponentModel.DataAnnotations;

namespace Book_Store.Attributes
{
    public class AllowedExtensionAttribute:ValidationAttribute
    {
        private readonly string _AllowedExtensions;

        public AllowedExtensionAttribute(string extensions)
        {
            this._AllowedExtensions = extensions;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension=Path.GetExtension(file.FileName);
                
                var isAllowed=_AllowedExtensions.Split(", ").Contains(extension,StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"This file extension is not allowed. Allowed extensions are: {_AllowedExtensions} .");
                }
            }
                    return ValidationResult.Success;

        }
    }
}
