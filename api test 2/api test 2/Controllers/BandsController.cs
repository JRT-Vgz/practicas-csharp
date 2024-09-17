using api_test_2.DTOs;
using api_test_2.Models;
using api_test_2.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace api_test_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private IBandsService<BandDto, BandInsertDto, BandUpdateDto> _bandsService;
        private IValidator<BandInsertDto> _bandInsertValidator;
        private IValidator<BandUpdateDto> _bandUpdateValidator;

        public BandsController(IBandsService<BandDto, BandInsertDto, BandUpdateDto> bandsService,
            IValidator<BandInsertDto> bandInsertValidator,
            IValidator<BandUpdateDto> bandUpdateValidator)
        {
            _bandsService = bandsService;
            _bandInsertValidator = bandInsertValidator;
            _bandUpdateValidator = bandUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BandDto>> Get() =>
            await _bandsService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<BandDto>> GetById(int id)
        {
            var bandDto = await _bandsService.GetById(id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }

        [HttpPost]
        public async Task<ActionResult<BandDto>> Add(BandInsertDto bandInsertDto)
        {
            var validationResult = await _bandInsertValidator.ValidateAsync(bandInsertDto);
            if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }

            var bandDto = await _bandsService.Add(bandInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = bandDto.BandID }, bandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BandDto>> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var validationResult = await _bandUpdateValidator.ValidateAsync(bandUpdateDto);
            if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }

            var bandDto = await _bandsService.Update(bandUpdateDto, id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var band = await _bandsService.Delete(id);

            return band == null ? NotFound() : Ok();
        }
    }
}
