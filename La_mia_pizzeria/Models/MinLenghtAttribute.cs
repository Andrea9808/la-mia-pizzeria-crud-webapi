using System.ComponentModel.DataAnnotations;

namespace La_mia_pizzeria.Models
{
    public class MinLenghtAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public MinLenghtAttribute() { }
        public MinLenghtAttribute(int minLenght)
        {
            MinLength = minLenght;
        }

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Split(' ').Length < MinLength)
            {
                return new ValidationResult($"Il campo non deve essere inferiore a {MinLength} parole");
            }

            return ValidationResult.Success;
        }
    }
}
