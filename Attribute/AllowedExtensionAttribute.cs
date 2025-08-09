namespace GamerCorner.Attribute
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtension;
        public AllowedExtensionAttribute(string allowedExtension)
        {
            _allowedExtension = allowedExtension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            
            if (file != null) 
            {
                var extension = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtension.Split(',').Contains(extension,StringComparer.OrdinalIgnoreCase);

                if (!isAllowed) 
                {
                    return new ValidationResult($"Only {_allowedExtension} are Allowed");
                }
            }
            return ValidationResult.Success;
        }
    }
}
