using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;

namespace PowerBITurkeyBlog.Core.Utilites.Results.Concrete
{
    public abstract class DataResult<TEntity> : Result, IDataResult<TEntity>
    {
        public DataResult(TEntity data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(TEntity data, bool success) : base(success)
        {
            Data = data;
        }

        public TEntity Data { get; }
    }
}
