using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApi.Configurations.Controller;

public class DemoOutputFormatter : IOutputFormatter
{
    public bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        return true;
    }

    public Task WriteAsync(OutputFormatterWriteContext context)
    {
        throw new NotImplementedException();
    }
}
