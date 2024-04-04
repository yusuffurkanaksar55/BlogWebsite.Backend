namespace PowerBITurkeyBlog.Core.Utilites.Results.Abstract
{
    public interface IDataResult<TEntity> : IResult
    {
        TEntity Data { get; }
    }
}
