using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Entities.Entities
{
	public class Account :IEntity
	{
		public int AccountId { get; set; }
		public int RoleId { get; set; }
		public string AccountName { get; set; }
		public string AccountEmail { get; set; }
		public string Password { get; set; }
		public DateTime CreateDate { get; set; }
		public ICollection<Comment>? Comments { get; set; }
		public required Role Role { get; set; }
	}
}
