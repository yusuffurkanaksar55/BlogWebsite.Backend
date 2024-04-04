using PowerBITurkeyBlog.Core.Entities;

namespace PowerBITurkeyBlog.Entities.Entities
{
	public class Role :IEntity
	{
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public ICollection<Account>? Accounts { get; set; }
	}
}
