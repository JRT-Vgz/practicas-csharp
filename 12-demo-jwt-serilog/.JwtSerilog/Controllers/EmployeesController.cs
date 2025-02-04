using CodigoFacilito.JwtSerilog.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodigoFacilito.JwtSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = ("Administrador"))]

        public IActionResult Get()
        {
            var listEmployee = DBContext.Employees;

            return Ok(listEmployee);
        }
    }
}
