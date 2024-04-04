using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Abstract
{
	public interface IArticleService : IGenericService<Article>
	{
		IDataResult<Article> GetArticleByCommentId(int commentId);
	}
}
