using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Host.Controllers;

[Route("api")]
[ApiController]
public class DemoController : Controller
{
    private readonly ILogger<DemoController> logger;
    public DemoController() { }


    [HttpGet]
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