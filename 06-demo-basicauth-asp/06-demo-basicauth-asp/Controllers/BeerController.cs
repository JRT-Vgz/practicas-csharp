using _06_demo_basicauth_asp.Models;
using _06_demo_basicauth_asp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _06_demo_basicauth_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;
        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Beer>> Get()
            => await _beerService.Get();
    }
}
