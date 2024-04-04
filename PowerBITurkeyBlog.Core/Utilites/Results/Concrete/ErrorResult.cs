namespace PowerBITurkeyBlog.Core.Utilites.Results.Concrete
{
	public class ErrorResult : Result
	{
		public ErrorResult(bool success, string message) : base(success, message)
		{
		}

		public ErrorResult(bool success) : base(success)
		{
		}
	}
}
