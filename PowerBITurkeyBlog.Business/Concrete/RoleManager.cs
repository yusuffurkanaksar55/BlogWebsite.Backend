using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Concrete
{
	public class RoleManager : IRoleService
	{
		private readonly IRoleDal _roleDal;

		public RoleManager(IRoleDal roleDal)
		{
			_roleDal = roleDal;
		}

		public IDataResult<List<Role>> GetAll()
		{
			return new SuccessDataResult<List<Role>>(_roleDal.GetAll().ToList(), "Roles Listed");
		}

		public async Task<IDataResult<Role?>> GetEntityById(int id)
		{
			if (id==null)
			{
				return new ErrorDataResults<Role?>("Id parameter is not found !");
			}

			var entity = await _roleDal.GetByIdAsync(id);
			return new SuccessDataResult<Role?>(entity, "Role Founded !");
		}

		public IResult AddEntity(Role entity)
		{
			if (entity==null)
			{
				return new ErrorResult(false, "Role is empty");
			}

			_roleDal.AddAsync(entity);
			return new SuccessResult(true, "Role Added !");
		}

		public IResult AddEntityRange(IEnumerable<Role> entities)
		{
			if (entities == null)
			{
				return new ErrorResult(false, "Roles is empty");
			}

			_roleDal.AddRangeAsync(entities);
			return new SuccessResult(true, "Roles Added !");
		}

		public IResult DeleteEntity(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id parameter can not be empty");
			}
			var entity = _roleDal.Where(x => x.RoleId == id).SingleOrDefault();
			_roleDal.Remove(entity);
			return new SuccessResult(true, "Role Deleted");
		}

		public IResult DeleteEntity(Role entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Role is empty");
			}

			_roleDal.Remove(entity);
			return new SuccessResult(true, "Role Deleted");
		}

		public IResult Update(Role entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Role is empty");
			}
			_roleDal.Update(entity);
			return new SuccessResult(true, "Role Updated");
		}

		public IResult AnyAsync(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id Parameter is empty");
			}

			return new Result(_roleDal.AnyAsync(x => x.RoleId == id).Result, $"{nameof(Role)} Not Found");
		}
	}
}
