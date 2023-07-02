using AutoMapper;
using AutoMapper.Models;
using AutoMapperDemo.Models;

namespace AutoMapperDemo;

public class SimpleMapperService
{
    private readonly IMapper _mapper;

    public SimpleMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public DstModel Map(SrcModel model)
    {
        var dto = _mapper.Map<DstModel>(model);
        return dto;
    }
}

public class ProjectionMapperService
{
    private readonly IMapper _mapper;
    public ProjectionMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public ProjectionModel Map(SrcModel model)
    {
        var dto = _mapper.Map<ProjectionModel>(model);
        return dto;
    }
}

public class NestedMapperService
{
    private readonly IMapper _mapper;
    public NestedMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public OuterDest Map(OuterSource model)
    {
        var dto = _mapper.Map<OuterDest>(model);
        return dto;
    }
}

public class ConstructionMapperService
{
    private readonly IMapper _mapper;
    public ConstructionMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public ConstructionSourceDto Map(ConstructionSource model)
    {
        var dto = _mapper.Map<ConstructionSourceDto>(model);
        return dto;
    }
}

public class FlatteningMapperService
{
    private readonly IMapper _mapper;
    public FlatteningMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public FlatteningOrderDto Map(FlatteningOrder model)
    {
        var dto = _mapper.Map<FlatteningOrderDto>(model);
        return dto;
    }
}

public class IncludeMembersMapperService
{
    private readonly IMapper _mapper;
    public IncludeMembersMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public FlatteningDestination Map(FlatteningSource model)
    {
        var dto = _mapper.Map<FlatteningDestination>(model);
        return dto;
    }
}