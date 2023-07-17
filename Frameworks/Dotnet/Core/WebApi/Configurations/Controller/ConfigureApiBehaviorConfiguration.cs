using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Configurations.Controller;

public class ConfigureApiBehaviorConfiguration
{
    public IActionResult DemoInvalidModelStateResponse(ActionContext context)
    {
        var descroption = context.ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
        var jsonResult = new ContentResult
        {
            StatusCode = 400,
            ContentType = "application/json",
            Content = new ErrorResponse
            {
                Error = "invalid-request",
                Description = descroption != null ? descroption.ErrorMessage : null
            }.Serialize()
        };

        return jsonResult;
    }
}