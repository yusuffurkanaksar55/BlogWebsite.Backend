using FluentValidation;
using PowerBITurkeyBlog.Entities.Entities;
using PowerBITurkeyBlog.Entities.OtherEntities;

namespace PowerBITurkeyBlog.Business.ValidationRules.FluentValidation
{
	public class AccountValidator : AbstractValidator<AccountDto> 
	{
		public AccountValidator()
		{
			RuleFor(x => x.AccountName).NotEmpty().NotNull().WithMessage("Account Name can't be empty.");
			RuleFor(x => x.AccountName).Length(5,100).WithMessage("Account Name must have max 5 character to 100");
			RuleFor(x=>x.AccountEmail).NotEmpty().NotNull().WithMessage("Account Email can't be empty.");
			RuleFor(x => x.AccountName).MinimumLength(10);
			RuleFor(x=>x.Password).NotEmpty().NotNull().WithMessage("Password can't be empty.");
		}
	}
}
