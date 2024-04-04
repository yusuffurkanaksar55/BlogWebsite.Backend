using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Concrete
{
	public class ArticleManager : IArticleService
	{
		private readonly IArticleDal _articleDal;

		public ArticleManager(IArticleDal articleDal)
		{
			_articleDal = articleDal;
		}

		public IDataResult<List<Article>> GetAll()
		{
			return new SuccessDataResult<List<Article>>(_articleDal.GetAll().ToList(), "Article Listed");
		}

		public async Task<IDataResult<Article?>> GetEntityById(int id)
		{
			if (id == null)
			{
				return new ErrorDataResults<Article?>("Id parameter not found");
			}

			var article = await _articleDal.GetByIdAsync(id);
			return new SuccessDataResult<Article?>(article, "Article Founded");
		}

		public IResult AddEntity(Article entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Article is empty");
			}

			_articleDal.AddAsync(entity);
			return new SuccessResult(true, "Article Added");
		}

		public IResult AddEntityRange(IEnumerable<Article> entities)
		{
			if (entities == null)
			{
				return new ErrorResult(false, "Articles is empty");
			}

			_articleDal.AddRangeAsync(entities);
			return new SuccessResult(true, "Articles Added");
		}

		public IResult DeleteEntity(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id parameter not found");
			}

			var article = _articleDal.Where(x => x.ArticleId == id).SingleOrDefault();
			_articleDal.Remove(article);
			return new SuccessResult(true, "Article Deleted");
		}

		public IResult DeleteEntity(Article entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Article is empty");
			}
			_articleDal.Remove(entity);
			return new SuccessResult(true, "Article Deleted");
		}

		public IResult Update(Article entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Article is empty");
			}
			_articleDal.Update(entity);
			return new SuccessResult(true, "Article Updated");
		}

		public IResult AnyAsync(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id Parameter is empty");
			}

			return new Result(_articleDal.AnyAsync(x => x.ArticleId == id).Result, $"{nameof(Article)} Not Found");
		}

		public IDataResult<Article> GetArticleByCommentId(int commentId)
		{
			if (commentId==null)
			{
				return new ErrorDataResults<Article>("Id Parameter is not found");
			}

			var article=_articleDal.GetArticleByCommentId(commentId);
			return new SuccessDataResult<Article>(article, "Article Founded");
		}
	}
}
