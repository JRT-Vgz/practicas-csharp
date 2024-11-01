using AutoMapper;
using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Models;
using csharp_api_demo_bands.Repository;

namespace csharp_api_demo_bands.Services
{
    public class StyleService : ICommonService<StyleDto, StyleInsertDto, StyleUpdateDto>
    {
        private IRepository<Style> _styleRepository;
        private IMapper _mapper;

        public StyleService(IRepository<Style> styleRepository,
            IMapper mapper)
        {
            _styleRepository = styleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StyleDto>> GetAll()
        {
            var styles = await _styleRepository.GetAll();

            return styles.Select(s => _mapper.Map<StyleDto>(s));
        }

        public async Task<StyleDto> GetById(int id)
        {
            var style = await _styleRepository.GetById(id);

            if (style == null) { return null; }

            var styleDto = _mapper.Map<StyleDto>(style);

            return styleDto;
        }

        public async Task<StyleDto> Insert(StyleInsertDto styleInsertDto)
        {
            var style = _mapper.Map<Style>(styleInsertDto);

            await _styleRepository.Insert(style);
            await _styleRepository.Save();

            var styleDto = _mapper.Map<StyleDto>(style);

            return styleDto;
        }

        public async Task<StyleDto> Update(StyleUpdateDto styleUpdateDto, int id)
        {
            var style = await _styleRepository.GetById(id);

            if (style == null) { return null; }

            style = _mapper.Map<StyleUpdateDto, Style>(styleUpdateDto, style);

            _styleRepository.Update(style);
            await _styleRepository.Save();

            var styleDto = _mapper.Map<StyleDto>(style);

            return styleDto;
        }
        public async Task<StyleDto> Delete(int id)
        {
            var style = await _styleRepository.GetById(id);

            if (style == null) { return null; };

            _styleRepository.Delete(style);
            await _styleRepository.Save();

            var styleDto = _mapper.Map<StyleDto>(style);

            return styleDto;
        }
    }
}
