using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PowerBITurkeyBlog.Core.Validations.FluentValidations
{
	public class ValidatorTool
	{
		public static void FluentValidate(IValidator validator, object entity)
		{
			var result = validator.Validate((IValidationContext)entity);
			if (result.Errors.Count > 0)
			{
				throw new ValidationException(result.Errors);
			}
		}
	}
}
