using AutoMapper;
using Demo_REST_API.DTOs;
using Demo_REST_API.Models;
using Demo_REST_API.Repository;
using Demo_REST_API.Validators;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Demo_REST_API.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;
        public List<string> Errors { get; }
        public BeerService(IRepository<Beer> beerRepository,
            IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();

        }

        public async Task<IEnumerable<BeerDto>> GetAll() 
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b));
        }


        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null)
            {
                return null;
            }

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }

        public async Task<BeerDto> Update(BeerUpdateDto beerUpdateDto, int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null)
            {
                return null;
            }

            beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer);

            _beerRepository.Update(beer);
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }
        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null)
            {
                return null;
            }

            _beerRepository.Delete(beer);
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }
        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if (_beerRepository.Search(b => b.Name == beerInsertDto.Name).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }
        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRepository.Search(b => b.Name == beerUpdateDto.Name 
            && beerUpdateDto.Id != b.BeerID).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }
    }
}
