using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;

namespace csharp_api_demo_bands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private ICommonService<StyleDto, StyleInsertDto, StyleUpdateDto> _styleService;
        private IValidator<StyleInsertDto> _styleInsertValidator;
        private IValidator<StyleUpdateDto> _styleUpdateValidator;

        public StyleController(ICommonService<StyleDto, StyleInsertDto, StyleUpdateDto> styleService,
            IValidator<StyleInsertDto> styleInsertValidator,
            IValidator<StyleUpdateDto> styleUpdateValidator)
        {
            _styleService = styleService;
            _styleInsertValidator = styleInsertValidator;
            _styleUpdateValidator = styleUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<StyleDto>> GetAll() =>
            await _styleService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<StyleDto>> GetById(int id)
        {
            var styleDto = await _styleService.GetById(id);

            return styleDto == null ? NotFound() : Ok(styleDto);
        }

        [HttpPost]
        public async Task<ActionResult<StyleDto>> Insert(StyleInsertDto styleInsertDto)
        {
            var validationResult = _styleInsertValidator.Validate(styleInsertDto);
            if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }

            var styleDto = await _styleService.Insert(styleInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = styleDto.Id }, styleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StyleDto>> Update(StyleUpdateDto styleUpdateDto, int id) 
        {
            var validationResult = _styleUpdateValidator.Validate(styleUpdateDto);
            if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }

            var styleDto = await _styleService.Update(styleUpdateDto, id);

            return styleDto == null ? NotFound() : Ok(styleDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StyleDto>> Delete(int id)
        {
            var styleDto = await _styleService.Delete(id);

            return styleDto == null ? NotFound() : Ok(styleDto);
        }
      
    }
}
