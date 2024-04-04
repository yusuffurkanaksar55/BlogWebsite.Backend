using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Core.Concrete.EntityFramework
{
	public class EfGenericRepository<TEntity,TContext> : IGenericRepository<TEntity>
		where TEntity : class, IEntity
		where TContext : DbContext
	{
		protected readonly TContext _context;

		public EfGenericRepository(TContext context)
		{
			_context = context;
		}

		public async Task<TEntity?> GetByIdAsync(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().AsNoTracking().AsQueryable();
		}

		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
		{
			return _context.Set<TEntity>().Where(expression);
		}

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _context.Set<TEntity>().AnyAsync(expression);
		}

		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _context.Set<TEntity>().AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}

		public void Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			_context.SaveChanges();
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			_context.SaveChanges();
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
			_context.SaveChanges();
		}
	}
}
