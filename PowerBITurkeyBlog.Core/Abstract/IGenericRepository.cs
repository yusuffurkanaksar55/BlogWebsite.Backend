using System.Linq.Expressions;
using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Core.Abstract
{
	public interface IGenericRepository<TEntity> where TEntity : class,IEntity
	{
		Task<TEntity?> GetByIdAsync(int id);
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
		Task AddAsync(TEntity entity);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
		void Update(TEntity entity);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
