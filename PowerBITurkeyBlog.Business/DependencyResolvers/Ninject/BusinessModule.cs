using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Business.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;

namespace PowerBITurkeyBlog.Business.DependencyResolvers.Ninject
{
	public class BusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IAccountService>().To<AccountManager>().InSingletonScope();
			Bind<IAccountDal>().To<EfAccountDal>().InSingletonScope();
			Bind<DbContext>().To<PowerBiTurkeyContext>();
		}
	}
}
