using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerAndConsumeServices.Services;

namespace SwaggerAndConsumeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            JWTServices jwtServices = new JWTServices();

            string token = jwtServices.GetToken("Vero");
            return Ok(token);
        }
    }
}
