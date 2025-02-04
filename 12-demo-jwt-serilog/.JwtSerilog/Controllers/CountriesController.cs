using CodigoFacilito.JwtSerilog.Data;

using Microsoft.AspNetCore.Mvc;

namespace CodigoFacilito.JwtSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ILogger<CountriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get all countries");

            var listCountry = DBContext.Countries;

            return Ok(listCountry);
        }
    }
}
