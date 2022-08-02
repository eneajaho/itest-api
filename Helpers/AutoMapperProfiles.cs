using AutoMapper;
using iTestApi.DTOs.Package;
using iTestApi.DTOs.Question;
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

            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<QuestionUpdateDto, Question>();
            
            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();
            
            
            
            
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