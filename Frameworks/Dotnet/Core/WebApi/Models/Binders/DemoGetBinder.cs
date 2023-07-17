using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace WebApi.Models.Binders;

public class DemoGetBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        DemoGetModel model = new DemoGetModel();

        string bodyAsText = await new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEndAsync();
        model = JsonConvert.DeserializeObject<DemoGetModel>(bodyAsText);
        if(model == null)
        {
            model = new DemoGetModel();
        }
        model.Authorization = bindingContext.HttpContext.Request.Headers["Authorization"];

        bindingContext.Model = model;
        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
    }
}