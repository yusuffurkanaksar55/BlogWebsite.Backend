using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBITurkeyBlog.Core.Utilites.Results.Concrete
{
	public class SuccessResult :Result
	{
		public SuccessResult(bool success, string message) : base(success, message)
		{
		}

		public SuccessResult(bool success) : base(success)
		{
		}
	}
}
