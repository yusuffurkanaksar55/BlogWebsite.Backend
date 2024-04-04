using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
	public class EfArticleDal : EfGenericRepository<Article,PowerBiTurkeyContext>,IArticleDal
	{
		public EfArticleDal(PowerBiTurkeyContext context) : base( context)
		{
		}

		public Article? GetArticleByCommentId(int commentId)
		{
			return _context.Articles.Include(x => x.Comments).SingleOrDefault(x => x.CommentId == commentId);
		}
	}
}
