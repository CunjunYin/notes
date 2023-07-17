using WebApi.Configurations.Controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        //options.ClientErrorMapping = { };
        options.InvalidModelStateResponseFactory = (context) => { return new ConfigureApiBehaviorConfiguration().DemoInvalidModelStateResponse(context); };
        //options.SuppressConsumesConstraintForFormFileParameters = true;
    });

// builder.Services.AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
