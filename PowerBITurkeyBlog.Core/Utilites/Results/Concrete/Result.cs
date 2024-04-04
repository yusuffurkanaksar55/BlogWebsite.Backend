using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;

namespace PowerBITurkeyBlog.Core.Utilites.Results.Concrete
{
	public class Result :IResult
	{
		public Result(bool success, string message) : this(success)
		{
			Message = message;
		}

		public Result(bool success)
		{
			IsSuccess = success;
		}
		public bool IsSuccess { get; }
		public string Message { get; }
	}
}
