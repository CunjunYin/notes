using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApi.Configurations.Controller;

public class DemoInputFormatter : IInputFormatter
{
    public bool CanRead(InputFormatterContext context)
    {
        return true;
    }

    public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    {
        throw new NotImplementedException();
    }
}