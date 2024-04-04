using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Abstract
{
	public interface IAccountDal : IGenericRepository<Account>
	{
		List<Account> GetAccountsWithRoleId(int roleId);
	}
}
