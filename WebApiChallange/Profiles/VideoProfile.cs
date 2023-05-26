using AutoMapper;
using WebApiChallange.Data.Dtos;
using WebApiChallange.Models;

namespace WebApiChallange.Profiles
{
	public class VideoProfile : Profile
	{
		public VideoProfile()
		{
			CreateMap<CreateVideoDto, Video>();
			CreateMap<UpdateVideoDto, Video>();
			CreateMap<Video, UpdateVideoDto>();
			CreateMap<Video, ReadVideoDto>();
		}
	}
}
