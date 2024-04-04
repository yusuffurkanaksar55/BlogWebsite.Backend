using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Abstract
{
	public interface ICommentDal : IGenericRepository<Comment>
	{
		List<Comment> GetCommentsByAccountId(int  accountId);
		List<Comment> GetCommentsByArticleId(int  articleId);
	}
}
