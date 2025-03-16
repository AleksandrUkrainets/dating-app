using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(member => member.Age, opt =>
                    opt.MapFrom(c => c.BirdthDate.AgeCalculate()))
                .ForMember(member => member.PhotoUrl, opt =>
                    opt.MapFrom(c => c.Photos.FirstOrDefault(p => p.IsMain)!.Url));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
