# AutoMapper
AutoMapper is a lightweight library that facilitates the mapping relationship between different entities. It provides an efficient solution by automating the mapping process, eliminating the need for writing repetitive mapping code manually.

AutoMapper is a valuable tool in large projects that implement code layering to decouple logics. After implementing layering, different entities are often required to fulfill the specific requirements of each layer. Layering approach is beneficial as it helps decouple the code and maintain separation of concerns. However, one common challenge is converting data models between layers, which can be a repetitive and tedious task if done manually.

Here's where AutoMapper comes into play as a convenient solution. It serves as a powerful data object conversion tool that simplifies the process of mapping data between objects. By configuring mapping rules and conventions, AutoMapper automates the mapping process, reducing the amount of manual mapping code required.

## Nuget Package
[AutoMapper](https://www.nuget.org/packages/AutoMapper)

## Startup

### Mapping Configuration
```csharp
// Profile Instances Method
public  class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Src, Dest>();
    }
}

// Use Mapper Configuration
var configuration = new MapperConfiguration(cfg => {
    cfg.CreateMap<Src, Dest>();
});

// ==============================
// Scan for all profiles in an assembly
// ==============================

// Using instance
var config = new MapperConfiguration(cfg => {
    cfg.AddMaps(myAssembly);
});
var configuration = new MapperConfiguration(cfg => cfg.AddMaps(myAssembly));

// Can also use assembly names:
var configuration = new MapperConfiguration(cfg =>
    cfg.AddMaps(new [] {
        "Foo.UI",
        "Foo.Core"
    });
);

// Or marker types for assemblies:
var configuration = new MapperConfiguration(cfg =>
    cfg.AddMaps(new [] {
        typeof(HomeController),
        typeof(Entity)
    });
);
```

### Object conversion
```csharp
var configuration = new MapperConfiguration(cfg =>
{ 
    cfg.AddProfile<MappingProfile>();
});

var mapper = configuration.CreateMapper();
var dest = mapper.Map<Dest>(new Src() { Name = "Name" });
```

### Naming Conventions
```csharp
// Individual Profile
public class MappingProfile : Profile
{
  public MappingProfile()
  {
    SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
    DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
  }
}

// Global Config
var configuration = new MapperConfiguration(cfg =>
{
    cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
});
```

### Replacing characters
```csharp
public class Source
{
    public int SrcValue { get; set; }
}
public class Destination
{
    public int DestValue { get; set; }
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Cause SrcValue to equal DestValue
        ReplaceMemberName("Src", "Dest");
        CreateMap<Src, Dest>();
    }
}
```

### Recognizing pre/postfixes
```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Cause SrcValue to equal DstValue
        RecognizePrefixes("before");
        RecognizePostfixes("after");
        CreateMap<Src, Dest>();
    }
}
```
> By default AutoMapper recognizes the prefix "Get" remove by `cfg.ClearPrefixes()`

### Control Mapping Fields and Attribute Ranges
```csharp
//TODO: Test
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ShouldMapField = fi => false;
        ShouldMapProperty = pi =>
            pi.GetMethod != null &&
            (pi.GetMethod.IsPublic || pi.GetMethod.IsPrivate);
        CreateMap<Src, Dest>();
    }
}
```

### Configuring visibility
AutoMapper only recognizes public members
```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ShouldMapProperty = p =>
            p.GetMethod.IsPublic ||
            p.GetMethod.IsAssembly;
        CreateMap<Src, Dest>();
    }
}
```

## Simple Mapping
### Lists and Arrays
> When mapping a collection property, if the source value is null AutoMapper will map the destination field to an empty collection rather than setting the destination value to null
```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AllowNullCollections = true;
        CreateMap<Src, Dest>();
    }
}
```

### Nested Mappings
```csharp
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

public class NestedMapperProfile : Profile
{
    public NestedMapperProfile()
    {
        CreateMap<OuterSource, OuterDest>();
        CreateMap<InnerSource, InnerDest>();
    }
}
```
### Inheritance
```csharp
public class InheritancePerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class InheritanceEmployee : InheritancePerson
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }
}

public class InheritancePersonDto
{
    public string Name { get; set; }
}

public class InheritanceEmployeeDto : InheritancePersonDto
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }
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
```

### Construction
```csharp
public class ConstructionSource
{
    public int Value { get; set; }
}

public class ConstructionSourceDto
{
    public ConstructionSourceDto(int valueParamSomeOtherName)
    {
        _value = valueParamSomeOtherName - 1;
    }

    private int _value;

    public int Value
    {
        get { return _value; }
    }
}

public class ConstructionMapperProfile : Profile
{
    public ConstructionMapperProfile()
    {
        CreateMap<ConstructionSource, ConstructionSourceDto>()
            // Only if If the destination constructor parameter names don’t match
            .ForCtorParam("valueParamSomeOtherName", opt => opt.MapFrom(src => src.Value));
    }
}
```
Disable constructor mapping:
```csharp
var configuration = new MapperConfiguration(cfg => cfg.DisableConstructorMapping());
```

When To use constructor mapping
```csharp
var configuration = new MapperConfiguration(cfg => cfg.ShouldUseConstructor = constructor => constructor.IsPublic);
```

### Attribute Mapping

```csharp
[AutoMap(typeof(Order))]
public class OrderDto {}

// Other arrtibutes
ReverseMap (bool)
ConstructUsingServiceLocator (bool)
MaxDepth (int)
PreserveReferences (bool)
DisableCtorValidation (bool)
IncludeAllDerived (bool)
TypeConverter (Type)
```

### Dictonary Mapping
```csharp
var configuration = new MapperConfiguration(cfg =>{});
var mapper = configuration.CreateMapper();
Dictionary<string, object> dic = new Dictionary<string, object>();
dic.Add("Name","name");
dic.Add("Age",18);
var dest = mapper.Map<Dest01>(dic);
```
> No Configuration, other mapping will fail

## Advance Mapping
### Type conversion
```csharp
public class SrcConverter
{
    public string Age { get; set; }
    public string Time { get; set; }
}
public class DestConverter
{
    public int Age { get; set; }
    public DateTime Time { get; set; }
}
public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {
        return System.Convert.ToDateTime(source);
    }
}

var configuration = new MapperConfiguration(cfg => {
    //Optional
    cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
    //Config to use Type Converter
    cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
    cfg.CreateMap<SrcConverter, DestConverter>();
});
var src = new SrcConverter
{
    Age = "5",
    Time = "05/12/2022"
};
var mapper = configuration.CreateMapper();
var dest = mapper.Map<DestConverter>(src);
```

### Custom Resolver 
```csharp
public class SrcResolver
{
    public string Name { get; set; }

    public int Age { get; set; }
}
public class DestResolver
{
    public string Info { get; set; }
}
public class CustomResolver : IValueResolver<SrcResolver, DestResolver, string>
{
    public string Resolve(SrcResolver source, DestResolver destination, string destMember, ResolutionContext context)
    {		
		return $"{source.Name}--{source.Age}";
	}
}

var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<SrcResolver, DestResolver>()
    .ForMember(dest => dest.Info, opt => opt.MapFrom(new CustomResolver()));
});
var mapper = configuration.CreateMapper();
var dest = mapper.Map<DestResolver>(new SrcResolver() { Name = "name", Age = 18 });
```

### Condictional Mapping
```csharp
var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<SrcCondition, DestCondition>()
    // Name length >=3 || Name+xxx >= 5
    .ForMember(dest => dest.Name, opt => opt.PreCondition(src => src.Name.Length >= 3))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name + "XXX"))
    .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name.Length >= 5))
});
var mapper = configuration.CreateMapper();
var dest = mapper.Map<DestCondition>(new SrcCondition() { Name = "name", Age = 18 });
```

### Null handling
```csharp
var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Src01, Dest01>()
    // if name == null, set name to "XXX"
    .ForMember(dest => dest.Name, opt => opt.NullSubstitute("XXX"));
});
var mapper = configuration.CreateMapper();
var dest = mapper.Map<Dest01>(new Src01() { Age = 18 });
```

### Pre|Post-mapping 
```csharp
var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Src, Dest>()
    .BeforeMap((src, dest) => { 
        Console.WriteLine("Pre mapping");
    })
    .AfterMap((src, dest) => {
        Console.WriteLine("Post mapping");
    });
});

var mapper = configuration.CreateMapper();
var dest = mapper.Map<Dest>(new Src() { Name = "zhangsan" });

// Duuring Map
var dest = mapper.Map<Src,Dest>(src, opt => {
    opt.BeforeMap((src, dest) => {src.Name = src.Name + " !!!"; });
    opt.AfterMap((src, dest) => {dest.Name = "fawaikuangtu " + dest.Name;});
});
```

### Reference 
[https://juejin.cn/post/7123014408535539742]