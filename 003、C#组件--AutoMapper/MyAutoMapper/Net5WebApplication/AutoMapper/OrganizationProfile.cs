using AutoMapper;

namespace Net5WebApplication.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => "fawaikuangtu " + src.Name));
        }
    }
}
