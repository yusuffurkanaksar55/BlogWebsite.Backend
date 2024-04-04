using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Abstract
{
	public interface IArticleDal :IGenericRepository<Article>
	{
		Article? GetArticleByCommentId(int commentId);
	}
}
