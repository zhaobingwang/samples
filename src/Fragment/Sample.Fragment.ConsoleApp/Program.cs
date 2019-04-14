using Sample.Data.Access.Dapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Transactions;
using Sample.Utilities;
using AutoMapper;

namespace Sample.Fragment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AutoMapper.Mapper.Initialize(cfg =>
                {
                    //cfg.CreateMap<Source, Destination>();
                    //cfg.AddProfile(new Source2DestinationProfile());
                    cfg.AddProfile<Source2DestinationProfile>();
                });
                Source src = new Source() { DBName = "test" };
                var dest = src.MapTo<Destination>();
                Console.WriteLine(dest.ViewName);
                //    UserOperator userOperator = new UserOperator();
                //    UserTagOperator userTagOperator = new UserTagOperator();
                //    using (var scope = new TransactionScope())
                //    {

                //    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常：{ex.Message}");
            }
        }
    }

    public class Source2DestinationProfile : Profile
    {
        public Source2DestinationProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(dest => dest.ViewName, options => options.MapFrom(src => src.DBName));
        }
    }

    class Test
    {
        [StringLength(4, ErrorMessage = "max length 4")]
        public string name { get; set; }
    }

    class Source
    {
        public string DBName { get; set; }
    }
    class Destination
    {
        public string ViewName { get; set; }
    }
}
