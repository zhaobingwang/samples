using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

            #region HelloWorld
            // 第一种方式
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
            });
            var mapper = config.CreateMapper();
            var dest = mapper.Map<Source, Destination>(new Source
            {
                Id = 1,
                Name = "test"
            });
            Console.WriteLine("==========Hello,World.==========");
            Console.WriteLine($"id:{dest.Id},name:{dest.Name}");

            var mapper2 = config.CreateMapper();
            var dest3 = mapper2.Map<Destination, Source>(new Destination
            {
                Id = 2,
                Name = "test2"
            });
            Console.WriteLine($"id:{dest3.Id},name:{dest3.Name}");

            // 第二种方式
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
            });
            var dest2 = Mapper.Map<Destination>(new Source
            {
                Id = 1,
                Name = "test"
            });
            Console.WriteLine($"id:{dest2.Id},name:{dest2.Name}");

            #endregion

            #region Flattening
            var customer = new Customer
            {
                Name = "test"
            };
            var order = new Order
            {
                Customer = customer
            };
            var product = new Product
            {
                Name = "Surface laptop",
                Price = 12999.99m
            };
            order.AddOrderLienItem(product, 3);

            var configFlattening = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>();
            });
            var mapperFlattening = configFlattening.CreateMapper();
            var dto = mapperFlattening.Map<Order, OrderDto>(order);
            Console.WriteLine("==========Flattening==========");
            Console.WriteLine($"{dto.CustomerName}\t{dto.Total}");
            #endregion

            #region Reverse Mapping and Unflattening

            #endregion

            #region Projection
            var configProjection = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                    .ForMember(dest1 => dest1.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                    .ForMember(dest1 => dest1.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                    .ForMember(dest1 => dest1.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));
            });
            var mapperProjection = configProjection.CreateMapper();
            var calendarEventForm = mapperProjection.Map<CalendarEvent, CalendarEventForm>(new CalendarEvent
            {
                Date = new DateTime(2019, 3, 23, 10, 10, 10),
                Title = "Go party."
            });
            Console.WriteLine($"{calendarEventForm.Title}-{calendarEventForm.EventDate}-{calendarEventForm.EventHour}-{calendarEventForm.EventMinute}");
            #endregion

            #region Configuration Validation
            var configConfigurationValidation = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceConfigurationValidation, DestinationConfigurationValidation>(MemberList.None)
                    .ForMember(dest5 => dest5.SomeValuefff, opt => opt.Ignore());
            });
            var mapperConfigurationValidation = configConfigurationValidation.CreateMapper();
            var destConfigurationValidation = mapperConfigurationValidation.Map<DestinationConfigurationValidation>(new SourceConfigurationValidation
            {
                SomeValue = "hi."
            });
            configConfigurationValidation.AssertConfigurationIsValid();
            Console.WriteLine("==========Configuration Validation==========");
            Console.WriteLine(destConfigurationValidation.SomeValuefff);
            #endregion

            #region Lists and Arrays
            // Lists and Arrays
            var configListsAndArrays = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;    // Handling null collections
                cfg.CreateMap<SourceListsAndArrays, DestinationListsAndArrays>();
            });
            var mapperListsAndArrays = configListsAndArrays.CreateMapper();
            var srcLists = new[] {
                new SourceListsAndArrays{ Value1=1},
                new SourceListsAndArrays{ Value1=2},
                new SourceListsAndArrays{ Value1=3}
            };
            srcLists = null;
            //SourceListsAndArrays[] src = null;
            var destListsAndArrays1 = mapperListsAndArrays.Map<SourceListsAndArrays[], IEnumerable<DestinationListsAndArrays>>(srcLists);
            var destListsAndArrays2 = mapperListsAndArrays.Map<SourceListsAndArrays[], ICollection<DestinationListsAndArrays>>(srcLists);
            var destListsAndArrays3 = mapperListsAndArrays.Map<SourceListsAndArrays[], IList<DestinationListsAndArrays>>(srcLists);
            var destListsAndArrays4 = mapperListsAndArrays.Map<SourceListsAndArrays[], List<DestinationListsAndArrays>>(srcLists);
            var destListsAndArrays5 = mapperListsAndArrays.Map<SourceListsAndArrays[], DestinationListsAndArrays[]>(srcLists);

            // Polymorphic element types in collections
            var configPolymorphic = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceListsAndArrays, DestinationListsAndArrays>()
                .Include<SourceListsAndArraysChild, DestinationListsAndArrayChild>();
                cfg.CreateMap<SourceListsAndArraysChild, DestinationListsAndArrayChild>();
            });
            var mapperPolymorphic = configPolymorphic.CreateMapper();
            var srcPolymorphic = new[] {
                new SourceListsAndArrays(),
                new SourceListsAndArraysChild(),
                new SourceListsAndArrays()
            };

            var destPolymorphic = mapperPolymorphic.Map<SourceListsAndArrays[], DestinationListsAndArrays[]>(srcPolymorphic);

            Console.WriteLine("==========Lists and Arrays==========");

            #endregion

            #region Nested Mappings
            var configNested = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OuterSource, OuterDest>();
                cfg.CreateMap<InnerSource, InnerDest>();
            });
            config.AssertConfigurationIsValid();

            var source = new OuterSource
            {
                Value = 5,
                Inner = new InnerSource { OtherValue = 15 }
            };
            var mapperNested = config.CreateMapper();
            var destNested = mapper.Map<OuterSource, OuterDest>(source);
            Console.WriteLine($"==========Nested Mappings==========");
            Console.WriteLine(destNested.Value);
            Console.WriteLine(destNested.Inner.OtherValue);
            #endregion

            #region Custom Type Converters
            var configCustomTypeConverter = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(2));
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing(new TypeTypeConverter());
                cfg.CreateMap<SourceCustomTypeConverter, DestinationCustomTypeConverter>();
            });
            var mapperCustomTypeConverter = configCustomTypeConverter.CreateMapper();
            var destCustomCustomTypeConverter = mapperCustomTypeConverter.Map<DestinationCustomTypeConverter>(new SourceCustomTypeConverter { Value1 = "1", Value2 = "2018-02-25", Value3 = $"{typeof(DestinationCustomTypeConverter)}" });
            Console.WriteLine($"==========Custom Type Converters==========");
            Console.WriteLine($"dest.value1:{destCustomCustomTypeConverter.Value1},dest.value2:{destCustomCustomTypeConverter.Value2},dest.value3:{destCustomCustomTypeConverter.Value3}");
            #endregion

            #region Custom Value Resolvers
            var configCustomValueResolvers = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceCustomValueResolver, DestinationCustomValueResolver>()
                .ForMember(dest4 => dest4.Total, opt => opt.MapFrom<CustomResolver>());
            });
            var sourceCustomValueResolver = new SourceCustomValueResolver { Value1 = 2, Value2 = 3 };
            var mapperCustomValueResolver = configCustomValueResolvers.CreateMapper();
            var destCustomValueResolver = mapperCustomValueResolver.Map<DestinationCustomValueResolver>(sourceCustomValueResolver);
            Console.WriteLine($"==========Custom Value Resolvers==========");
            Console.WriteLine($"src.value1:{sourceCustomValueResolver.Value1},src.value2:{sourceCustomValueResolver.Value2},dest.Total:{destCustomValueResolver.Total}");
            #endregion
        }
    }

    #region HelloWorld
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region Flattening
    public class Order
    {
        private readonly List<OrderLineItem> _orderLineItems = new List<OrderLineItem>();
        public Customer Customer { get; set; }
        public OrderLineItem[] GetOrderLineItems()
        {
            return _orderLineItems.ToArray();
        }
        public void AddOrderLienItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }
        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }
    #endregion

    #region Reverse Mapping and Unflattening

    #endregion

    #region Projection
    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }

    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
    #endregion

    #region Configuration Validation
    public class SourceConfigurationValidation
    {
        public string SomeValue { get; set; }
    }

    public class DestinationConfigurationValidation
    {
        public string SomeValuefff { get; set; }
    }
    #endregion

    #region Lists and Arrays
    public class SourceListsAndArrays
    {
        public int Value1 { get; set; }
    }
    public class DestinationListsAndArrays
    {
        public int Value1 { get; set; }
    }
    public class SourceListsAndArraysChild : SourceListsAndArrays
    {
        public int Value2 { get; set; }
    }
    public class DestinationListsAndArrayChild : DestinationListsAndArrays
    {
        public int Value2 { get; set; }
    }
    #endregion

    #region Nested Mappings
    public class OuterSource
    {
        public int Value { get; set; }
        public InnerSource Inner { get; set; }
    }
    public class InnerSource
    {
        public int OtherValue { get; set; }
    }
    public class OuterDest
    {
        public int Value { get; set; }
        public InnerDest Inner { get; set; }
    }
    public class InnerDest
    {
        public int OtherValue { get; set; }
    }
    #endregion

    #region Custom Type Converters
    public class SourceCustomTypeConverter
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
    public class DestinationCustomTypeConverter
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

    #region Custom Value Resolvers
    public class SourceCustomValueResolver
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
    public class DestinationCustomValueResolver
    {
        public int Total { get; set; }
    }
    public class CustomResolver : IValueResolver<SourceCustomValueResolver, DestinationCustomValueResolver, int>
    {
        public int Resolve(SourceCustomValueResolver source, DestinationCustomValueResolver destination, int destMember, ResolutionContext context)
        {
            return source.Value1 + source.Value2;
        }
    }
    #endregion
}
