using CodigoFacilito.JwtSerilog.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodigoFacilito.JwtSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [Authorize]

        public IActionResult Get()
        {
            var listProduct = DBContext.Products;

            return Ok(listProduct);
        }
    }
}
