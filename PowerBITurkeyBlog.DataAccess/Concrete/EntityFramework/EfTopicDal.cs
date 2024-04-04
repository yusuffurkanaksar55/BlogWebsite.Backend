using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
	public class EfTopicDal : EfGenericRepository<Topic,PowerBiTurkeyContext>,ITopicDal
	{
		public EfTopicDal(PowerBiTurkeyContext context) : base(context)
		{
		}
	}
}
