using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperConsoleApp
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Age2, opt => opt.Condition(src => src.Age > 0 && src.Age < 150))    // 条件映射
                .ForMember(dest => dest.Age2, opt => opt.MapFrom(src => src.Age));
        }
    }
}
