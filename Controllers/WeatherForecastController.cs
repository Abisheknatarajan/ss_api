using Microsoft.AspNetCore.Mvc;
using UseCaseInterfaces;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IHomeUseCase Homeusecase;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IHomeUseCase homeuseCase, ILogger<WeatherForecastController> logger)
    {
        Homeusecase = homeuseCase;
        _logger = logger;
    }

    public class NameRequest
    {
        public string Name { get; set; }
    }

    [HttpPost("test")]
    public IActionResult Get([FromBody] NameRequest request)
    {
        var name = request.Name;
        var result = Homeusecase.execute(name);

        return StatusCode(200, result);
    }

}
