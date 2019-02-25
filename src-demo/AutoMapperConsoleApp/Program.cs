using AutoMapper;
using System;
using System.Diagnostics;
using System.Reflection;

namespace AutoMapperConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            //string currentUserName = "test";    // 在实际业务操作中，在Mapper.Map的时候创建映射前后的回调函数，赋值：currentUserName=HttpContext.Current.Identity.Name

            //var user = new User { Id = 1, NickName = "张三", Age = 10 };

            // The static API:
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<User, UserDTO>()
            //        .ForMember(dest => dest.Age, opt => opt.Condition(src => src.Age > 0 && src.Age < 150))    // 条件映射
            //        .AfterMap((src, dest) => dest.NickName = currentUserName);    // 映射（前）后操作
            //});

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<UserMappingProfile>();    // 添加一个配置文件
            //});


            //// The instance API:
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<UserMappingProfile>();
            //});

            //var mapper = config.CreateMapper();
            //// or
            //IMapper mapper2 = new Mapper(config);

            //var userDTO = mapper.Map<User, UserDTO>(user);
            //var userDTO2 = mapper2.Map<User, UserDTO>(user);


            ////var userDTO = Mapper.Map<UserDTO>(user);

            //System.Console.WriteLine($"{userDTO.Age2} {userDTO.NickName}");
            //System.Console.WriteLine($"{userDTO2.Age2} {userDTO2.NickName}"); 
            #endregion

            #region Custom Type Converters
            var configCustom = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(2));
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing(new TypeTypeConverter());
                cfg.CreateMap<SourceCustom, DestinationCustom>();
            });
            var mapperCustom = configCustom.CreateMapper();
            var destCustom = mapperCustom.Map<DestinationCustom>(new SourceCustom { Value1 = "1", Value2 = "2018-02-25", Value3 = $"{typeof(DestinationCustom)}" });
            Console.WriteLine($"dest.value1:{destCustom.Value1},dest.value2:{destCustom.Value2},dest.value3:{destCustom.Value3}");
            #endregion
        }
    }

    #region Custom Type Converters
    public class SourceCustom
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
    public class DestinationCustom
    {
        public int Value1 { get; set; }
        public DateTime Value2 { get; set; }
        public Type Value3 { get; set; }
    }
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }
    public class TypeTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(string source, Type destination, ResolutionContext context)
        {
            return Assembly.GetExecutingAssembly().GetType(source);
        }
    }
    #endregion

}
