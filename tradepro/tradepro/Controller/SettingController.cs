
using Microsoft.AspNetCore.Mvc;
using tradepro.Client.Common.Model;

[ApiController]
[Route("api/configuration")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigurationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetConfiguration()
    {
        var apiUrl = _configuration["ApiUrl"];

        return Ok(new Setting
        {
            ApiUrl = apiUrl
        });
    }
}
