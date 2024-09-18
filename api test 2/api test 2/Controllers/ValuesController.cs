using api_test_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_test_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BandsContext _context;
        public ValuesController(BandsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Style>> Get()
        {
            return await _context.Styles.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var style = await _context.Styles.FindAsync(id);
            if (style == null) { return NotFound(); }
            _context.Styles.Remove(style);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
