using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Entities.Entities;
using PowerBITurkeyBlog.Entities.OtherEntities;

namespace PowerBITurkeyBlog.WebAPI.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public AccountController(IAccountService accountService, IMapper mapper)
		{
			_accountService = accountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAccounts()
		{
			var accounts = _accountService.GetAll().Data;
			var accountsDtos = _mapper.Map<List<AccountDto>>(accounts.ToList());
			return CreateActionResult(CustomResponseDto<List<AccountDto>>.SuccessCustomResponseDto(200, accountsDtos));
		}


		[HttpGet("{id}")]
		public IActionResult GetAccountsById(int id)
		{
			var account=  _accountService.GetEntityById(id).Result.Data;
			var accountsDto = _mapper.Map<AccountDto>(account);
			return CreateActionResult(CustomResponseDto<AccountDto>.SuccessCustomResponseDto(200, accountsDto));
		}

		[HttpPost]
		public IActionResult Save(AccountDto accountDto)
		{
			var checkAddEntityAccount = _accountService.AddEntity(_mapper.Map<Account>(accountDto));

			var account = _mapper.Map<Account>(accountDto);
			var accountAddDto = _mapper.Map<AccountDto>(account);

			return checkAddEntityAccount.IsSuccess
				? CreateActionResult(CustomResponseDto<AccountDto>.SuccessCustomResponseDto(201, accountAddDto))
				: BadRequest(accountAddDto);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var account = _accountService.GetEntityById(id).Result.Data;
			var checkDeleteEntity = _accountService.DeleteEntity(account);

			return checkDeleteEntity.IsSuccess
				? CreateActionResult(CustomResponseDto<NoContentDto>.SuccessCustomResponseDto(201))
				: BadRequest();

		}
	}
}
