using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Abstract
{
	public interface IAccountService : IGenericService<Account>
	{
		IDataResult<List<Account>> GetAccountsByRole(int roleId);
	}
}
