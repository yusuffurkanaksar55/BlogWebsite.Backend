using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfGenericRepository<Role, PowerBiTurkeyContext>, IRoleDal
    {
	    public EfRoleDal(PowerBiTurkeyContext context) : base( context)
	    {
	    }
    }
}
