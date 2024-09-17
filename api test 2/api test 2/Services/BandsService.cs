using api_test_2.DTOs;
using api_test_2.Mappers;
using api_test_2.Models;
using api_test_2.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api_test_2.Services
{
    public class BandsService : IBandsService<BandDto, BandInsertDto, BandUpdateDto>
    {
        private ICommonRepository<Band> _bandsRepository;
        private IMapper _mapper;
        public BandsService(ICommonRepository<Band> bandsRepository,
            IMapper mapper) 
        {
            _bandsRepository = bandsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BandDto>> Get()
        {
            var bands = await _bandsRepository.Get();

            return bands.Select(b => _mapper.Map<BandDto>(b));
        }


        public async Task<BandDto> GetById(int id)
        {
            var band = await _bandsRepository.GetById(id);

            if (band == null) { return null; }

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
        public async Task<BandDto> Add(BandInsertDto bandInsertDto)
        {
            var band = _mapper.Map<Band>(bandInsertDto);

            await _bandsRepository.Add(band);
            await _bandsRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var band = await _bandsRepository.GetById(id);

            if (band == null) { return null; }

            band = _mapper.Map<BandUpdateDto, Band>(bandUpdateDto, band);

            _bandsRepository.Update(band);
            await _bandsRepository.Save(); 

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
        public async Task<BandDto> Delete(int id)
        {
            var band = await _bandsRepository.GetById(id);

            if (band == null) { return null; }

            _bandsRepository.Delete(band);
            await _bandsRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
    }
}
