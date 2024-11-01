using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Services;
using csharp_api_demo_bands.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_api_demo_bands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private BandService _bandService;
        private IValidator<BandInsertDto> _bandInsertValidator;
        private IValidator<BandUpdateDto> _bandUpdateValidator;

        public BandController(BandService bandService,
            IValidator<BandInsertDto> bandInsertValidator,
            IValidator<BandUpdateDto> bandUpdateValidator)
        {
            _bandService = bandService;
            _bandInsertValidator = bandInsertValidator;
            _bandUpdateValidator = bandUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BandDto>> GetAll() =>
            await _bandService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<BandDto>> GetById(int id)
        {
            var bandDto = await _bandService.GetById(id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }

        [HttpPost]
        public async Task<ActionResult<BandDto>> Insert(BandInsertDto bandInsertDto)
        {
            var formValidation = _bandInsertValidator.Validate(bandInsertDto);
            if (!formValidation.IsValid) { return BadRequest(formValidation.Errors); }

            var serviceValidation = await _bandService.Validate(bandInsertDto);
            if (!serviceValidation) { return BadRequest(_bandService.Errors); }

            var bandDto = await _bandService.Insert(bandInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = bandDto.BandID }, bandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BandDto>> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var formValidation = _bandUpdateValidator.Validate(bandUpdateDto);
            if (!formValidation.IsValid) { return BadRequest(formValidation.Errors); }

            var serviceValidation = await _bandService.Validate(bandUpdateDto);
            if (!serviceValidation) { return BadRequest(_bandService.Errors); }

            var bandDto = await _bandService.Update(bandUpdateDto, id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BandDto>> Delete(int id)
        {
            var bandDto = await _bandService.Delete(id);

            return bandDto == null ? NotFound() : Ok(bandDto);
        }
    }
}
