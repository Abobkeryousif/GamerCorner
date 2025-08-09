namespace GamerCorner.Attribute
{
     public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;
        public MaxFileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                
                if (file.Length > _maxSize)
                {
                    return new ValidationResult($"Max Size Allowed: {_maxSize} bytes");
                }
            }
            return ValidationResult.Success;
        }  
    }
}
