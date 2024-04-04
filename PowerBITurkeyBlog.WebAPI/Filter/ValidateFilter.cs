using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PowerBITurkeyBlog.Entities.OtherEntities;

namespace PowerBITurkeyBlog.WebAPI.Filter
{
	public class ValidateFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

				context.Result =
					new BadRequestObjectResult(CustomResponseDto<NoContentDto>.FailCustomResponseDto(400, errors));
			}
		}
	}
}
