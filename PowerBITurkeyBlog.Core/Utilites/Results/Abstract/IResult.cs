namespace PowerBITurkeyBlog.Core.Utilites.Results.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
