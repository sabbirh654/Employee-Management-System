using EMS.Repository.Models;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEmployeeService _employeeService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var emp = new Employee
            {
                Name = "Sabbir Hasan",
                Email = "sabbirh1000@gmail.com",
                Address = "Dhaka",
                Phone = "1234567",
                DOB = new DateTime(1990, 12, 12),
                DepartmentId = 1006,
                DesignationId = 1,
            };

            var res = await _employeeService.GetAllEmployees();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
