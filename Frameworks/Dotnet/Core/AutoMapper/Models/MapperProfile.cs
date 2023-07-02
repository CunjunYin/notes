using AutoMapper;
using AutoMapper.Models;
using System;

namespace AutoMapperDemo.Models;

public class SimpleMapperProfile : Profile
{
    public SimpleMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<SrcModel, DstModel>();
        
    }
}

public class ProjectionMapperProfile : Profile
{
    public ProjectionMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<SrcModel, ProjectionModel>()
            .ForMember(d => d.EventDate, o => o.MapFrom(src => src.Date.Date))
            .ForMember(d => d.EventHour, o => o.MapFrom(src => src.Date.Hour))
            .ForMember(d => d.EventMinute, o => o.MapFrom(src => src.Date.Minute));
    }
}

public class NestedMapperProfile : Profile
{
    public NestedMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<OuterSource, OuterDest>();
        CreateMap<InnerSource, InnerDest>();
    }
}

public class ConstructionMapperProfile : Profile
{
    public ConstructionMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<ConstructionSource, ConstructionSourceDto>()
            // Only if If the destination constructor parameter names don’t match
            .ForCtorParam("valueParamSomeOtherName", opt => opt.MapFrom(src => src.Value));
    }
}

public class FlatteningMapperProfile : Profile
{
    public FlatteningMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<FlatteningOrder, FlatteningOrderDto>()
            // Optional if property NAME matched to the GetNAME()
            .ForMember(d => d.Total, o => o.MapFrom(s => s.GetTotal()))
            // Optional if Dependent NAME matched to the Combined Name (CustomerName)
            .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.Name));
    }
}

public class IncludeMembersMapperProfile : Profile
{
    public IncludeMembersMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<FlatteningSource, FlatteningDestination>().IncludeMembers(s => s.InnerSource, s => s.OtherInnerSource);
        CreateMap<FlatteningInnerSource, FlatteningDestination>(MemberList.None);
        CreateMap<FlatteningOtherInnerSource, FlatteningDestination>();
    }
}

public class ReverseMapperProfile : Profile
{
    public ReverseMapperProfile()
    {
        // Conofig
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        // Define your mappings here
        CreateMap<ReverseMappingModelOrder, ReverseMappingModelCustomer>()
            .ReverseMap();
    }
}

public class InheritanceProfile : Profile
{
    public InheritanceProfile()
    {
        CreateMap<InheritancePerson, InheritancePersonDto>()
            .ForMember(d => d.Name, o => o.MapFrom(o => $"{o.FirstName} {o.LastName}"));
        CreateMap<InheritanceEmployee, InheritanceEmployeeDto>()
            // Inheriting mapping configuration from a base class
            .IncludeBase<InheritancePerson, InheritancePersonDto>();
    }
}


