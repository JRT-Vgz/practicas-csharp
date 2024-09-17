using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_API_1.DTOs;
using Test_API_1.Models;
using Test_API_1.Services;

namespace Test_API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private IBandsService _bandsService;
        private IValidator<BandInsertDto> _bandInsertValidator;
        private IValidator<BandUpdateDto> _bandUpdateValidator;

        public BandsController(IBandsService bandsService,
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
        public async Task<ActionResult<BandDto>> Insert(BandInsertDto bandInsertDto)
        {
            var validationResult = _bandInsertValidator.Validate(bandInsertDto);

            if (!validationResult.IsValid) 
            { 
                return BadRequest(validationResult.Errors); 
            }

            if (!_bandsService.Validate(bandInsertDto))
            {
                return BadRequest(_bandsService.Errors);
            }

            var bandDto = await _bandsService.Insert(bandInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = bandDto.BandID }, bandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BandDto>> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var validationResult = _bandUpdateValidator.Validate(bandUpdateDto);

            if (!validationResult.IsValid)
            { 
                return BadRequest(validationResult.Errors); 
            }

            if (!_bandsService.Validate(bandUpdateDto))
            {
                return BadRequest(_bandsService.Errors);
            }

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
