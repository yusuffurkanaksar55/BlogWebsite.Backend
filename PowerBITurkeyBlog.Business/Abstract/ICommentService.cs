using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Abstract
{
	public interface ICommentService :IGenericService<Comment>
	{
		IDataResult<List<Comment>> GetCommentsByAccountId(int accountId);
		IDataResult<List<Comment>> GetCommentsByArticleId(int articleId);
	}
}
