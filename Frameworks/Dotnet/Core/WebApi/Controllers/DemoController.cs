using WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class DemoController : Controller
{
    private readonly ILogger<DemoController> logger;

    public DemoController()
    { }

    [HttpGet]
    public async Task<IActionResult> DemoGet(DemoGetModel model)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> DemoPost()
    {
        return StatusCode(403);
    }

    [HttpPut]
    public async Task<IActionResult> DemoPut(string param)
    {
        if (string.IsNullOrWhiteSpace(param))
        {
            return BadRequest();
        }

        return Ok();
    }
}