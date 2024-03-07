using System.ComponentModel.DataAnnotations;

namespace Services.Helpers
{
    public static class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValidPerson = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValidPerson)
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
}
