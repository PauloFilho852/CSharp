using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validations
{
    public class PrimeiraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            //Validação já sendo feita com [Required]
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;
            
            string? primeiraLetra = value.ToString()?[0].ToString();

            if (primeiraLetra != primeiraLetra?.ToUpper())
                return new ValidationResult("A primeia letra do nome deve ser maiúcula.");


            return ValidationResult.Success;
        }
    }
}
