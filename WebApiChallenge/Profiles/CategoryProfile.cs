using AutoMapper;
using WebApiChallange.Data.Dtos;
using WebApiChallange.Models;

namespace WebApiChallange.Profiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<CreateCategoryDto, Category>();
			CreateMap<UpdateCategoryDto, Category>();
			CreateMap<Category, UpdateCategoryDto>();
			CreateMap<Category, ReadCategoryDto>();
		}
	}
}
