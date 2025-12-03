using System.ComponentModel.DataAnnotations;

namespace _202230548_CoffeeShop.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if ((DateOnly)value > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("Sale cannot be in the future");
            }
            return ValidationResult.Success;
        }
    }
}
