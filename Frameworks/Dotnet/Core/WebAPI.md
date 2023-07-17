# ControllerBase vs Controller
Use ControllerBase when you only want API service, use Controller when you need views. Controller inhereted from ControllerBase, so it contain extra functionality.

# Attributes


# Configure Api Behavior Options
## Automatically 400 response
The [ApiController] attribute makes model validation errors automatically trigger an HTTP 400 response. Consequently, the following code is unnecessary in an action method:
```csharp
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```
Customize response message
```csharp
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = (context) => { ... }
    });
```

Disable response message
```csharp
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
```

options.InvalidModelStateResponseFactory = (context) =>
## Suppress Map Client Errors
SuppressMapClientErrors is used to suppress mapping of the default mapping behavior of HTTP status codes, by default is set to false. When it's `false` it will add additional message to the response. Example:
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.3",
    "title": "Forbidden",
    "status": 403,
    "traceId": "00-3bdb11f21ae757f7d0edfaa41003fac2-3ad8be4b183a0e84-00"
}
```
Customize message by configure the Http status code message 
```csharp
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.ClientErrorMapping[403].Link = "https://google.com";
    });
```
# Use Consumes to control media type
By default controller support all media type.By using [Consumes] attribute we can limit media type.
```csharp
[HttpPost]
[Consumes("application/xml")]
public IActionResult CreateProduct(Product product)
```
### Use case: Different media type to different controller
```csharp
[ApiController]
[Route("api/[controller]")]
public class ConsumesController : ControllerBase
{
    [HttpPost]
    [Consumes("application/json")]
    public IActionResult PostJson(IEnumerable<int> values) =>
        Ok(new { Consumes = "application/json", Values = values });

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult PostForm([FromForm] IEnumerable<int> values) =>
        Ok(new { Consumes = "application/x-www-form-urlencoded", Values = values });
}
```

# 
The PUT and PATCH methods are used to update an existing resource. The difference between them is that PUT replaces the entire resource, while PATCH specifies only the changes.

