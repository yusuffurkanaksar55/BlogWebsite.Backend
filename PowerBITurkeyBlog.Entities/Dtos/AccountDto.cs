namespace PowerBITurkeyBlog.Entities.OtherEntities
{
	public class AccountDto
	{
		public int AccountId { get; set; }
		public int RoleId { get; set; }
		public string AccountName { get; set; }
		public string AccountEmail { get; set; }
		public string Password { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
