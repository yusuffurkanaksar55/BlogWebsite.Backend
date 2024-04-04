using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using System.Linq.Expressions;

namespace PowerBITurkeyBlog.Core.Abstract
{
	public interface IGenericService<TEntity> where TEntity : class
	{
		IDataResult<List<TEntity>> GetAll();
		Task<IDataResult<TEntity>> GetEntityById(int id);
		IResult AddEntity(TEntity entity);
		IResult AddEntityRange(IEnumerable<TEntity> entities);
		IResult DeleteEntity(int id);
		IResult DeleteEntity(TEntity entity);
		IResult Update(TEntity entity);
		IResult AnyAsync(int id);
	}
}
