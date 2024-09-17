using Microsoft.EntityFrameworkCore;
using Test_api_3.Models;

namespace Test_api_3.Repository
{
    public class BandsRepository : IRepository<Band>
    {
        private BandsContext _bandsContext;
        public BandsRepository(BandsContext bandsContext)
        {
            _bandsContext = bandsContext;
        }

        public async Task<IEnumerable<Band>> GetAll() =>
            await _bandsContext.Bands.ToListAsync();

        public async Task<Band> GetById(int id) =>
            await _bandsContext.Bands.FindAsync(id);
        public async Task Add(Band band) =>
            await _bandsContext.Bands.AddAsync(band);
        public void Update(Band band)
        {
            _bandsContext.Bands.Attach(band);
            _bandsContext.Bands.Entry(band).State = EntityState.Modified;
        }

        public void Delete(Band band) =>
            _bandsContext?.Bands.Remove(band);

        public async Task Save() =>
            await _bandsContext.SaveChangesAsync();
    }
}
