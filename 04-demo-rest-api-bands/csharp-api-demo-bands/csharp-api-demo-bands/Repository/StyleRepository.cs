using csharp_api_demo_bands.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_demo_bands.Repository
{
    public class StyleRepository : IRepository<Style>
    {
        private BandsContext _bandsContext;

        public StyleRepository(BandsContext bandsContext) 
        {
            _bandsContext = bandsContext;
        }

        public async Task<IEnumerable<Style>> GetAll() =>
            await _bandsContext.Styles.ToListAsync();

        public async Task<Style> GetById(int id) => 
            await _bandsContext.Styles.FindAsync(id);

        public async Task Insert(Style style) =>
            await _bandsContext.Styles.AddAsync(style);

        public void Update(Style style)
        {
            _bandsContext.Styles.Attach(style);
            _bandsContext.Styles.Entry(style).State = EntityState.Modified;
        }

        public void Delete(Style style) =>
            _bandsContext.Styles.Remove(style);

        public async Task Save() =>
            await _bandsContext.SaveChangesAsync();
    }
}
