using Microsoft.EntityFrameworkCore;
using Test_API_1.DTOs;
using Test_API_1.Models;

namespace Test_API_1.Services
{
    public class BandsService : IBandsService
    {
        private MetalContext _metalContext;
        public BandsService(MetalContext metalContext) 
        {
            _metalContext = metalContext;
        }

        public async Task<IEnumerable<BandDto>> Get() =>
            await _metalContext.Bands.Select(b => new BandDto()
            {
                BandID = b.BandID,
                Name = b.Name,
                StyleID = b.StyleID
            }).ToListAsync();

        public async Task<BandDto> GetById(int id)
        {
            var band = await _metalContext.Bands.FindAsync(id);

            if (band == null)
            {
                return null;
            }

            var bandDto = new BandDto()
            {
                BandID = band.BandID,
                Name = band.Name,
                StyleID = band.StyleID
            };

            return bandDto;
        }

        public async Task<BandDto> Insert(BandInsertDto bandInsertDto)
        {
            var band = new Band()
            {
                Name = bandInsertDto.Name,
                StyleID = bandInsertDto.StyleID
            };

            await _metalContext.Bands.AddAsync(band);
            await _metalContext.SaveChangesAsync();

            var bandDto = new BandDto()
            {
                BandID = band.BandID,
                Name = band.Name,
                StyleID = band.StyleID
            };

            return bandDto;
        }

        public async Task<BandDto> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var band = await _metalContext.Bands.FindAsync(id);

            if (band == null) { return null; }

            band.Name = bandUpdateDto.Name;
            band.StyleID = bandUpdateDto.StyleID;

            await _metalContext.SaveChangesAsync();

            var bandDto = new BandDto()
            {
                BandID = band.BandID,
                Name = band.Name,
                StyleID = band.StyleID
            };

            return bandDto;
        }
        public async Task<BandDto> Delete(int id)
        {
            var band = await _metalContext.Bands.FindAsync(id);

            if (band == null) { return null; }

            _metalContext.Bands.Remove(band);
            await _metalContext.SaveChangesAsync();

            var bandDto = new BandDto()
            {
                BandID = band.BandID,
                Name = band.Name,
                StyleID = band.StyleID
            };

            return bandDto;
        }
    }
}
