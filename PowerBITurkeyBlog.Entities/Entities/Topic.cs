using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Entities.Entities
{
	public class Topic :IEntity
	{
		public int TopicId { get; set; }
		public int TopicTitle { get; set; }
		public DateTime CreateDate { get; set; }
		public ICollection<Article> Articles { get; set; }
	}
}
