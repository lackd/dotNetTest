using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Musicfy.Core.Extension
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DateIsValidAttribute : ValidationAttribute
    {
        public string? Format { get; set; }
        private const string FORMAT_NOT_VALID = "El formato de la fecha no es válido";

        /// <summary>Validates the specified value with respect to the current validation attribute.</summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <exception cref="T:System.InvalidOperationException">The current attribute is malformed.</exception>
        /// <exception cref="T:System.NotImplementedException">
        /// <see cref="M:System.ComponentModel.DataAnnotations.ValidationAttribute.IsValid(System.Object,System.ComponentModel.DataAnnotations.ValidationContext)" /> has not been implemented by a derived class.</exception>
        /// <returns>An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? dateString = value as string;
            if (string.IsNullOrWhiteSpace(dateString))
            {
                return ValidationResult.Success; 
            }

            bool success = DateTime.TryParseExact(dateString, Format, null, DateTimeStyles.AssumeUniversal, out DateTime _);
            return success ? ValidationResult.Success : throw new ValidationException(FORMAT_NOT_VALID);
        }
    }
}