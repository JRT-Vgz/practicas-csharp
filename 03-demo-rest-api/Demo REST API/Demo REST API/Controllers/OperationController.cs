using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public int Get(int a, int b)
        {
            return a + b;
        }

        [HttpPost]
        public int Add(Numbers numbers, [FromHeader(Name = "Content-Length")] string CL)
        {
            Console.WriteLine(CL);
            return numbers.A - numbers.B;
        }
    }

    public class Numbers
    {
        public int A { get; set; }
        public int B { get; set; }
    }

}

