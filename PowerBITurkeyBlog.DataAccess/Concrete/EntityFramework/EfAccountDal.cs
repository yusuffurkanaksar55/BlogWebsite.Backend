using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
	public class EfAccountDal : EfGenericRepository<Account, PowerBiTurkeyContext>, IAccountDal
	{
		public EfAccountDal(PowerBiTurkeyContext context) : base(context)
		{
		}

		public List<Account> GetAccountsWithRoleId(int roleId)
		{
			return _context.Accounts.Include(x => x.Role).Where(x => x.RoleId == roleId).ToList();
		}
	}

}
