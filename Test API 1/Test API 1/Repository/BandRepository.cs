using Microsoft.EntityFrameworkCore;
using Test_API_1.DTOs;
using Test_API_1.Models;

namespace Test_API_1.Repository
{
    public class BandRepository : IBandRepository
    {
        private MetalContext _metalContext;

        public BandRepository(MetalContext metalContext)
        {
            _metalContext = metalContext;
        }

        public async Task<IEnumerable<Band>> Get() =>
            await _metalContext.Bands.ToListAsync();

        public async Task<Band> GetById(int id) =>
            await _metalContext.Bands.FindAsync(id);

        public async Task Insert(Band band) =>
            await _metalContext.Bands.AddAsync(band);

        public void Update(Band band)
        {
            _metalContext.Bands.Attach(band);
            _metalContext.Bands.Entry(band).State = EntityState.Modified;
        }

        public void Delete(Band band) =>
            _metalContext.Bands.Remove(band);

        public async Task Save() =>
            await _metalContext.SaveChangesAsync();

    }
}
