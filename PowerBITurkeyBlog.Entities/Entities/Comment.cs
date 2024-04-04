using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Entities.Entities
{
	public class Comment :IEntity
	{
		public int CommentId { get; set; }
		public int ArticleId { get; set; }
		public int AccountId { get; set; }
		public string CommentText { get; set; }
		public DateTime CreateDate { get; set; }
		public Account Account { get; set; }
		public Article Article { get; set; }
	}
}
