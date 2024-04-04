using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBITurkeyBlog.Core.Utilites.Results.Concrete
{
	public class ErrorDataResults<TEntity> : DataResult<TEntity>
	{
		public ErrorDataResults(TEntity data, string message) : base(data, false, message)
		{

		}

		public ErrorDataResults(TEntity data) : base(data, false)
		{

		}

		public ErrorDataResults(string message) : base(default, false, message)
		{

		}

		public ErrorDataResults() : base(default, false)
		{

		}
	}
}
