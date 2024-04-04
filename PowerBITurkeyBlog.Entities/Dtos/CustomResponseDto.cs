using System.Text.Json.Serialization;

namespace PowerBITurkeyBlog.Entities.OtherEntities
{
	public class CustomResponseDto<T>
	{
		public T Data { get; set; }
		public List<string> Errors { get; set; }

		[JsonIgnore]
		public int StatusCode { get; set; }

		public static CustomResponseDto<T> SuccessCustomResponseDto(int statusCode, T data)
		{
			return new CustomResponseDto<T>() { StatusCode = statusCode, Data = data };
		}
		public static CustomResponseDto<T> SuccessCustomResponseDto(int statusCode)
		{
			return new CustomResponseDto<T>() { StatusCode = statusCode };
		}
		public static CustomResponseDto<T> FailCustomResponseDto(int statusCode, List<string> errorsList)
		{
			return new CustomResponseDto<T>() { StatusCode = statusCode, Errors = errorsList };
		}
		public static CustomResponseDto<T> FailCustomResponseDto(int statusCode, string error)
		{
			return new CustomResponseDto<T>() { StatusCode = statusCode, Errors = new List<string> { error } };
		}
	}
}
