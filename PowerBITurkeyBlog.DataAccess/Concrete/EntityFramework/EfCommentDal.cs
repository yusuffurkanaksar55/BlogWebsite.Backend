using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
	public class EfCommentDal :EfGenericRepository<Comment,PowerBiTurkeyContext>,ICommentDal
	{
		public EfCommentDal(PowerBiTurkeyContext context) : base(context)
		{
		}

		public List<Comment> GetCommentsByAccountId(int accountId)
		{
			return _context.Comments.Include(x=>x.Account).Where(x=>x.AccountId==accountId).ToList();
		}

		public List<Comment> GetCommentsByArticleId(int articleId)
		{
			return _context.Comments.Include(x => x.Article).Where(x => x.ArticleId == articleId).ToList();
		}
	}
}
