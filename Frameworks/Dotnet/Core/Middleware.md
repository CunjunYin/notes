# Middleware
## Use，Run，Map Methods

### Run
`Run` is a terminal middleware method, it executes the delegate method and returns the result. It will not call any subsequent middleware components after execution.
```csharp
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});
```

### Use
`Use` is a non-terminal middleware method, it executes the delegate method and use `next` to call subsequent middleware components in the pipeline. By not calling `next`, it can short-circuit the pipeline.
```csharp
app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});
```

### Map
`Map` is a branching middleware method, it branch the pipeline based on the request path or other conditions. Map can use both `Run` and `Use` method.

#### Simple Map
```csharp
app.Map("/map", HandleMapTest);
static void HandleMapTest(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test");
    });
}
```

#### Nested Map
```csharp
app.Map("/nested", HandleNestedMapTest);
static void HandleNestedMapTest(IApplicationBuilder app)
{
    app.Map("/child", child => {
        child.Run(async context =>
        {
            await context.Response.WriteAsync("Nested Map");
        });
    });
}
```

#### MapWhen
```csharp
app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);
static void HandleBranchAndRejoin(IApplicationBuilder app)
{
    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>(); 

    app.Use(async (context, next) =>
    {
        var branchVer = context.Request.Query["branch"];
        logger.LogInformation("Branch used = {branchVer}", branchVer);

        // Do work that doesn't write to the Response.
        await next();
        // Do other work that doesn't write to the Response.
    });
}
```

## Middleware Class
```csharp
public static class MiddlewareExtension
{
    public static IApplicationBuilder UseDemoMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<DemoMiddleware>();
    }
}

public class DemoMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Log the incoming request path
        string requestPath = context.Request.Path;
        Console.WriteLine($"Request path: {requestPath}");

        // Call the next middleware in the pipeline
        await next(context);
    }
}

app.UseDemoMiddleware();
```