using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PowerBITurkeyBlog.Entities.Entities;
using PowerBITurkeyBlog.Entities.OtherEntities;

namespace PowerBITurkeyBlog.Business.Mapping.AutoMapper
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<Account, AccountDto>().ReverseMap();
		}
	}
}
