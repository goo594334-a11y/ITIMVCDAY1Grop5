using System.ComponentModel.DataAnnotations;

namespace ITIMVCDAY1Grop5.Validation
{
    public class MinDegreeLessThanDegreeAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }

        public MinDegreeLessThanDegreeAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {OtherPropertyName}");
            }

            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);
            if (otherValue == null)
            {
                return ValidationResult.Success;
            }

            if (decimal.TryParse(value.ToString(), out decimal currentValue) &&
                decimal.TryParse(otherValue.ToString(), out decimal otherPropertyValue))
            {
                // If applied on MinDegree (comparing against Degree): MinDegree must be less than Degree
                if (validationContext.MemberName == "MinDegree" || OtherPropertyName == "Degree")
                {
                    if (currentValue >= otherPropertyValue)
                    {
                        return new ValidationResult(
                            ErrorMessage ?? "Minimum Degree must be less than Total Degree.",
                            new[] { validationContext.MemberName ?? "MinDegree" }
                        );
                    }
                }
                // If applied on Degree (comparing against MinDegree): Degree must be greater than MinDegree
                else if (validationContext.MemberName == "Degree" || OtherPropertyName == "MinDegree")
                {
                    if (currentValue <= otherPropertyValue)
                    {
                        return new ValidationResult(
                            ErrorMessage ?? "Total Degree must be greater than Minimum Degree.",
                            new[] { validationContext.MemberName ?? "Degree" }
                        );
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
