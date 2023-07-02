using AutoMapper;
using AutoMapper.Models;
using AutoMapperDemo.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace AutoMapperDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var provider = serviceCollection.BuildServiceProvider();
        var mapper = provider.GetService<IMapper>();
        // Demo Code
        #region Simple Mapper
        var simpleMapperService = new SimpleMapperService(mapper);
        var simpleModel = simpleMapperService.Map(
            new SrcModel { Id = 1, Description = "SrcModel Description", Name = "SrcModel", Price = 10 }
        );
        #endregion

        #region Projection
        var projectionMapperService = new ProjectionMapperService(mapper);
        var projectionModel = projectionMapperService.Map(
            new SrcModel { Id = 1, Description = "SrcModel Description", Name = "SrcModel", Price = 10, Date = DateTime.Now }
        );
        #endregion

        #region Nested  Model
        var source = new OuterSource
        {
            Value = 5,
            Inner = new InnerSource { OtherValue = 15 }
        };
        var nestedMapperService = new NestedMapperService(mapper);
        var nestedModel = nestedMapperService.Map(source);
        #endregion

        #region Constructor
        var construction = new ConstructionMapperService(mapper);
        var constructionModel = construction.Map(new ConstructionSource { Value = 5 });
        #endregion

        #region Flattening
        var order = new FlatteningOrder
        {
            Customer = new FlatteningCustomer{Name = "George Costanza"}
        };
        var bosco = new FlatteningProduct
        {
            Name = "Bosco",
            Price = 4.99m
        };
        order.AddOrderLineItem(bosco, 15);

        var flattening = new FlatteningMapperService(mapper);
        var flatteningModel = flattening.Map(order);
        #endregion

        #region
        var flatteningSource = new FlatteningSource
        {
            Name = "name",
            InnerSource = new FlatteningInnerSource { Description = "description" },
            OtherInnerSource = new FlatteningOtherInnerSource { Title = "title" }
        };

        var includeMembers = new IncludeMembersMapperService(mapper);
        var includeMembersModel = includeMembers.Map(flatteningSource);
        #endregion

        #region Inheritance
        var employee = new InheritanceEmployee
        {
            FirstName = "John",
            LastName = "Doe",
            EmployeeId = "123",
            Salary = 5000
        };

        var dto = mapper.Map<InheritanceEmployeeDto>(employee);
        #endregion
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        //services.AddAutoMapper(config =>
        //{
        //    config.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        //    config.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        //    config.CreateMap<SrcModel, DstModel>();
        //});

        services.AddAutoMapper(
            typeof(SimpleMapperProfile),
            typeof(ProjectionMapperProfile),
            typeof(ConstructionMapperProfile),
            typeof(IncludeMembersMapperProfile)
        );
    }
}