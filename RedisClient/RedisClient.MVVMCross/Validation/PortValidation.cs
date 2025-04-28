using System.Globalization;
using System.Windows.Controls;

namespace RedisClient.MVVMCross.Validation
{
	public sealed class PortValidation : ValidationRule
	{
		public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
		{
			if (value == null)
				return new ValidationResult(false, "Port cannot be empty.");

			var parsed = int.TryParse(value.ToString(), out int portValue);
			if (!parsed)
				return new ValidationResult(false, "Port must be a number");

			if (portValue < 0 || portValue > 99999)
				return new ValidationResult(false, "Port value can not be less than 0 or more than 9999.");

			return ValidationResult.ValidResult;
		}
	}
}
