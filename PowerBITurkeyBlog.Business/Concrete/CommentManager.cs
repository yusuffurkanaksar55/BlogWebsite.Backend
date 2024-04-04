using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public IDataResult<List<Comment>> GetAll()
		{
			return new SuccessDataResult<List<Comment>>(_commentDal.GetAll().ToList(), "Comments Listed");
		}

		public async Task<IDataResult<Comment?>> GetEntityById(int id)
		{
			if (id == null)
			{
				return new ErrorDataResults<Comment?>("Id Parameter can not found !");
			}

			var comment = await _commentDal.GetByIdAsync(id);
			return new SuccessDataResult<Comment?>(comment, "Comment Found It");
		}

		public IResult AddEntity(Comment entity)
		{
			if (entity==null)
			{
				return new ErrorResult(false, "Comment is empty");
			}

			_commentDal.AddAsync(entity);
			return new SuccessResult(true, "Comment Added !");
		}

		public IResult AddEntityRange(IEnumerable<Comment> entities)
		{
			if (entities == null)
			{
				return new ErrorResult(false, "Comments is empty");
			}

			_commentDal.AddRangeAsync(entities);
			return new SuccessResult(true, "Comment Added !");
		}

		public IResult DeleteEntity(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id Parameter not found!");
			}

			var comment = _commentDal.Where(x => x.CommentId == id).SingleOrDefault();
			_commentDal.Remove(comment);
			return new SuccessResult(true, "Comment Deleted !");
		}

		public IResult DeleteEntity(Comment entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Comment not found!");
			}

			_commentDal.Remove(entity);
			return new SuccessResult(true, "Comment Deleted !");
		}

		public IResult Update(Comment entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Comment not found!");
			}
			_commentDal.Update(entity);
			return new SuccessResult(true, "Comment Updated");
		}

		public IDataResult<List<Comment>> GetCommentsByAccountId(int accountId)
		{
			if (accountId == null)
			{
				return new ErrorDataResults<List<Comment>>("Id Parameter not found");
			}

			var comments = _commentDal.GetCommentsByAccountId(accountId);
			return new SuccessDataResult<List<Comment>>(comments, "Comments Listed By Account Id");
		}

		public IDataResult<List<Comment>> GetCommentsByArticleId(int articleId)
		{
			if (articleId == null)
			{
				return new ErrorDataResults<List<Comment>>("Id Parameter not found");
			}

			var comments = _commentDal.GetCommentsByArticleId(articleId);
			return new SuccessDataResult<List<Comment>>(comments, "Comments Listed By Article Id");
		}
	}
}
