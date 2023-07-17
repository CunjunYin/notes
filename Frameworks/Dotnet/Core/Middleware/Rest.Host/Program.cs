using Core.Extensions;
using Core.Middlewares;
using Core.Models.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IModelBinder, DemoGetBinder>();
builder.Services.AddSingleton<DemoMiddleware>();

var app = builder.Build();
app.Map("/map/seg", HandleMultiSeg); // Segment map
app.Map("/map", HandleMapTest); // Simple map
app.Map("/nested", HandleNestedMapTest); // Nested map
app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.UseDemoMiddleware();
app.MapControllers();
app.Run();

static void HandleMapTest(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test");
    });
}

static void HandleNestedMapTest(IApplicationBuilder app)
{
    app.Map("/child", child => {
        child.Run(async context =>
        {
            await context.Response.WriteAsync("Nested Map");
        });
    });
}

static void HandleMultiSeg(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}

static void HandleBranch(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var branchVer = context.Request.Query["branch"];
        await context.Response.WriteAsync($"Branch used = {branchVer}");
    });
}

