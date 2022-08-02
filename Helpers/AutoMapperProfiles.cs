using AutoMapper;
using iTestApi.DTOs.Package;
using iTestApi.DTOs.User;
using iTestApi.Entities;

namespace iTestApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, AuthUserDto>();
            CreateMap<User, UserDto>();

            CreateMap<AuthUserDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();

            // CreateMap<Package, PackageDto>();
            // CreateMap<PackageDto, Package>();
            // CreateMap<PackageUpdateDto, Package>();
            // CreateMap<PackageCreateDto, Package>();


            // .ForMember(dest => dest.PhotoUrl, opt
            //     => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            // .ForMember(dest => dest.Age, opt
            //     => opt.MapFrom(src => src.Birthday.CalculateAge()));
            // CreateMap<MemberUpdateDto, User>();
        }
    }
}