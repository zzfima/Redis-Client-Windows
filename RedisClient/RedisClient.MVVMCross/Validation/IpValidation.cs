using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace RedisClient.MVVMCross.Validation
{
	public sealed class IpValidation : ValidationRule
	{
		public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
		{
			if (value == null)
				return new ValidationResult(false, "IP cannot be empty.");

			var isValid = Regex.IsMatch(value.ToString(), "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

			if (!isValid)
				return new ValidationResult(false, "IP is not valid");

			return ValidationResult.ValidResult;
		}
	}
}
