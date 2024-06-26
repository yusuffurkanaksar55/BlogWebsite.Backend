using System.Reflection;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Business.ValidationRules.FluentValidation;
using PowerBITurkeyBlog.Core.Aspects.PostSharp;
using PowerBITurkeyBlog.Core.Entities;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Concrete
{
	public class AccountManager : IAccountService
	{
		private readonly IAccountDal _accountDal;

		public AccountManager(IAccountDal accountDal)
		{
			_accountDal = accountDal;
		}


		public IDataResult<List<Account>> GetAll()
		{
			return new SuccessDataResult<List<Account>>(_accountDal.GetAll().ToList(),"Accounts Listed");
		}

		public async Task<IDataResult<Account?>> GetEntityById(int id)
		{
			if (id == null)
			{
				return new ErrorDataResults<Account?>("Id Parameter can not found !");
			}
			var entity = await _accountDal.GetByIdAsync(id);

			if (entity == null)
			{
				return new ErrorDataResults<Account?>("Account is empty");
			}

			return new SuccessDataResult<Account?>(entity, "Account Founded !");
		}
		[FluentValidationAspect(typeof(AccountDtoValidator))]
		public IResult AddEntity(Account entity)
		{
			if (entity==null)
			{
				return new ErrorResult(false,"Account can not be empty !");
			}

			_accountDal.AddAsync(entity);
			return new SuccessResult(true, "Account Added");
		}
		[FluentValidationAspect(typeof(AccountDtoValidator))]
		public IResult AddEntityRange(IEnumerable<Account> entities)
		{
			if (!entities.Any())
			{
				_accountDal.AddRangeAsync(entities);
				return new SuccessResult(true, "Accounts Added");
			}

			return new ErrorResult(false, "Accounts can not be empty");
		}
		[FluentValidationAspect(typeof(AccountDtoValidator))]
		public IResult DeleteEntity(int id)
		{
			if (id==null)
			{
				return new ErrorResult(false, "Id parameter can not be empty");
			}
			var entity=_accountDal.Where(x=>x.AccountId==id).SingleOrDefault();
			_accountDal.Remove(entity);
			return new SuccessResult(true, "Account Deleted");

		}
		[FluentValidationAspect(typeof(AccountDtoValidator))]
		public IResult DeleteEntity(Account entity)
		{
			if (entity==null)
			{
				return new ErrorResult(false, "Account is empty");
			}

			_accountDal.Remove(entity);
			return new SuccessResult(true, "Account Deleted");
		}

		public IResult Update(Account entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Account is empty");
			}

			_accountDal.Update(entity);
			return new SuccessResult(true, "Account Updated");
		}

		public IResult AnyAsync(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id Parameter is empty");
			}

			return new Result(_accountDal.AnyAsync(x => x.AccountId == id).Result, $"{nameof(Account)} Not Found");
		}

		public IDataResult<List<Account>> GetAccountsByRole(int roleId)
		{
			if (roleId == null)
			{
				return new ErrorDataResults<List<Account>>("Accounts not found!");
			}

			var accounts = _accountDal.GetAccountsWithRoleId(roleId);

			return new SuccessDataResult<List<Account>>(accounts, "Accounts Listed");
		}
	}
}
