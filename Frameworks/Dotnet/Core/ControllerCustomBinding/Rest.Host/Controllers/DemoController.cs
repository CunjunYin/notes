using Core;
using Core.Attributes;
using Core.Models;
using Core.Models.Binders;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Controllers;

[Route("api")]
[ApiController]
public class DemoController : Controller
{
    private readonly ILogger<DemoController> logger;
    public DemoController() { }


    [HttpGet]
    [ValidateModel(Order = 1)]
    [Route("get")]
    public async Task<IActionResult> DemoGet(DemoGetModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> DemoPost()
    {
        return NotFound();
    }
}