using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    
    public UserController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }



    [HttpGet(Name = "GetUser")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55)
        }).ToArray();
    }
}