using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Entities.Entities
{
	public class Article : IEntity
	{
		public int ArticleId { get; set; }
		public int TopicId { get; set; }
		public int CommentId { get; set; }
		public string Content { get; set; }
		public DateTime CreateDate { get; set; }
		public ICollection<Comment>? Comments { get; set; }
		public Topic Topic { get; set; }
	}
}
