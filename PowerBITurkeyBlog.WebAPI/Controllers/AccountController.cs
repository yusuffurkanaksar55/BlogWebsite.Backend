using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Entities.Entities;
using PowerBITurkeyBlog.Entities.OtherEntities;
using FluentValidation.Results;

namespace PowerBITurkeyBlog.WebAPI.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;
		private readonly IValidator <AccountDto> _validator;

		public AccountController(IAccountService accountService, IMapper mapper, IValidator<AccountDto> validator)
		{
			_accountService = accountService;
			_mapper = mapper;
			_validator = validator;
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
			var accountIsSuccess = _accountService.AnyAsync(id).IsSuccess;

			if (!accountIsSuccess)
			{
				return CreateActionResult(CustomResponseDto<AccountDto>.FailCustomResponseDto(404, _accountService.AnyAsync(id).Message));
			}

			var accountsDto = _mapper.Map<AccountDto>(account);
			return CreateActionResult(CustomResponseDto<AccountDto>.SuccessCustomResponseDto(200, accountsDto));
		}

		[HttpPost]
		public async Task<IActionResult> Save(AccountDto accountDto)
		{
			var account = _mapper.Map<Account>(accountDto);
			var accountAddDto = _mapper.Map<AccountDto>(account);
			ValidationResult result = await _validator.ValidateAsync(accountAddDto);

			if (!result.IsValid)
			{
				return CreateActionResult(
					CustomResponseDto<NoContentDto>.FailCustomResponseDto(404,
						_accountService.AddEntity(account).Message));
			}

			var checkAddEntityAccount = _accountService.AddEntity(_mapper.Map<Account>(account));

			return checkAddEntityAccount.IsSuccess
				? CreateActionResult(CustomResponseDto<AccountDto>.SuccessCustomResponseDto(201, accountAddDto))
				: BadRequest(accountAddDto);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var account = _accountService.GetEntityById(id).Result.Data;
			var checkDeleteEntity = _accountService.AnyAsync(id).IsSuccess;

			return checkDeleteEntity
				? CreateActionResult(CustomResponseDto<NoContentDto>.SuccessCustomResponseDto(201))
				: CreateActionResult(
					CustomResponseDto<NoContentDto>.FailCustomResponseDto(404, _accountService.AnyAsync(id).Message));

		}
	}
}
