using csharp_api_demo_bands.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_demo_bands.Repository
{
    public class BandRepository : IRepository<Band>
    {
        private BandsContext _bandContext;

        public BandRepository(BandsContext bandContext)
        {
            _bandContext = bandContext;
        }

        public async Task<IEnumerable<Band>> GetAll() =>
            await _bandContext.Bands.ToListAsync();

        public async Task<Band> GetById(int id) =>
            await _bandContext.Bands.FindAsync(id);

        public async Task Insert(Band band) =>
            await _bandContext.Bands.AddAsync(band);

        public void Update(Band band)
        {
            _bandContext.Bands.Attach(band);
            _bandContext.Bands.Entry(band).State = EntityState.Modified;
        }

        public void Delete(Band band) =>
            _bandContext.Bands.Remove(band);

        public async Task Save() =>
            await _bandContext.SaveChangesAsync();
    }
}
