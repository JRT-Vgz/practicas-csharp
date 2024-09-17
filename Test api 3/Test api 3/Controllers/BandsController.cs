using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Test_api_3.DTOs;
using Test_api_3.Services;
using Test_api_3.Validators;

namespace Test_api_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private ICommonService<BandDto, BandInsertDto, BandUpdateDto> _bandsService;
        private IValidator<BandInsertDto> _bandInsertValidator;
        private IValidator<BandUpdateDto> _bandUpdateValidator;
        public BandsController(ICommonService<BandDto, BandInsertDto, BandUpdateDto> bandsService,
            IValidator<BandInsertDto> bandInsertValidator,
            IValidator<BandUpdateDto> bandUpdateValidator)
        {
            _bandsService = bandsService;
            _bandInsertValidator = bandInsertValidator;
            _bandUpdateValidator = bandUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BandDto>> GetAll() =>
            await _bandsService.GetAll();

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
        public async Task<ActionResult<BandDto>> Delete(int id)
        {
            var bandDto = await _bandsService.Delete(id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }
    }
}
