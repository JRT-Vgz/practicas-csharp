using AutoMapper;
using Test_api_3.DTOs;
using Test_api_3.Models;
using Test_api_3.Repository;

namespace Test_api_3.Services
{
    public class BandsService : ICommonService<BandDto, BandInsertDto, BandUpdateDto>
    {
        private IRepository<Band> _bandsRepository;
        private IMapper _mapper;
        public BandsService(IRepository<Band> bandRepository,
            IMapper mapper)
        {
            _bandsRepository = bandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BandDto>> GetAll()
        {
            var bands = await _bandsRepository.GetAll();

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

            band = await _bandsRepository.GetById(band.BandID);

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

            if (band == null ) { return null; }

            _bandsRepository.Delete(band);
            await _bandsRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
    }
}
