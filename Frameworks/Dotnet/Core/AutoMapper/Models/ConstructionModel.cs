namespace AutoMapperDemo.Models;

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