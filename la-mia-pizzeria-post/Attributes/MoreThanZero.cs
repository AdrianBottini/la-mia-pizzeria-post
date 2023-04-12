using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Attributes
{
    public class MoreThanZero : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext _)
        {
            var input = Convert.ToDouble(value);

            if (input <= 0)
            {
                return new ValidationResult(ErrorMessage ?? "Il campo deve esserer maggiore di zero");
            }

            return ValidationResult.Success!;
        }
    }
}
