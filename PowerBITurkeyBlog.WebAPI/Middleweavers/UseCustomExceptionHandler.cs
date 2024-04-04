using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using PowerBITurkeyBlog.Business.Exceptions;
using PowerBITurkeyBlog.Entities.OtherEntities;

namespace PowerBITurkeyBlog.WebAPI.Middleweavers
{
	public class UseCustomExceptionHandler
	{
		public static void UserException(IApplicationBuilder builder)
		{
			builder.UseExceptionHandler(config =>
			{
				config.Run(async context =>
				{
					context.Response.ContentType = "application/json";
					var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

					var statusCode = exceptionFeature?.Error switch
					{
						ClientSideException => 400,
						_ => 500
					};

					context.Response.StatusCode = statusCode;

					var response =
						CustomResponseDto<NoContentDto>.FailCustomResponseDto(statusCode,
							exceptionFeature.Error.Message);

					await context.Response.WriteAsync(JsonSerializer.Serialize(response));


				});
			});


		}
	}
}
