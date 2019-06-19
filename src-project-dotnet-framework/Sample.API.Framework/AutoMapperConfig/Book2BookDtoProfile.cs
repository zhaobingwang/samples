using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Framework.AutoMapperConfig
{
    /// <summary>
    /// Book实体类转为Book数据传输对象配置文件
    /// </summary>
    public class Book2BookDtoProfile : Profile
    {
        public Book2BookDtoProfile()
        {
            CreateMap<Models.Book, DTOs.BookDto>()
                .ForMember(dest => dest.author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}