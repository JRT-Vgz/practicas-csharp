using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test_API_1.DTOs;
using Test_API_1.Models;
using Test_API_1.Repository;

namespace Test_API_1.Services
{
    public class BandsService : IBandsService
    {
        private IBandRepository _bandRepository;
        private IMapper _mapper;
        public List<string> Errors { get; }

        public BandsService(IBandRepository bandRepository,
            IMapper mapper) 
        {
            _bandRepository = bandRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BandDto>> Get()
        {
            var bands = await _bandRepository.Get();

            return bands.Select(b => _mapper.Map<BandDto>(b));
        }

        public async Task<BandDto> GetById(int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null)
            {
                return null;
            }

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Insert(BandInsertDto bandInsertDto)
        {
            var band = _mapper.Map<Band>(bandInsertDto);

            await _bandRepository.Insert(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null) { return null; }

            band = _mapper.Map<BandUpdateDto, Band>(bandUpdateDto, band);

            _bandRepository.Update(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
        public async Task<BandDto> Delete(int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null) { return null; }

            _bandRepository.Delete(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public bool Validate(BandInsertDto bandInsertDto)
        {
            if (bandInsertDto.Name == "Manowar")
            {
                Errors.Add("Manowar no es metal de verdad.");
                return false;
            }
            return true;
        }

        public bool Validate(BandUpdateDto bandUpdateDto)
        {
            if (bandUpdateDto.Name == "Manowar")
            {
                Errors.Add("Manowar no es metal de verdad.");
                return false;
            }
            return true;
        }
    }
}
