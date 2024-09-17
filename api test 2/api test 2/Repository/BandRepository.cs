using api_test_2.DTOs;
using api_test_2.Models;
using Microsoft.EntityFrameworkCore;

namespace api_test_2.Repository
{
    public class BandRepository : ICommonRepository<Band>
    {
        private BandsContext _bandsContext;

        public BandRepository(BandsContext bandsContext)
        {
            _bandsContext = bandsContext;
        }

        public async Task<IEnumerable<Band>> Get() =>
            await _bandsContext.Bands.ToListAsync();

        public async Task<Band> GetById(int id) =>
            await _bandsContext.Bands.FindAsync(id);

        public async Task Add(Band band) =>
            _bandsContext.Bands.Add(band);

        public void Update(Band band)
        {
            _bandsContext.Bands.Attach(band);
            _bandsContext.Entry(band).State = EntityState.Modified;
        }

        public void Delete(Band band) =>
            _bandsContext.Bands.Remove(band);

        public async Task Save() =>
            await _bandsContext.SaveChangesAsync();
    }
}
