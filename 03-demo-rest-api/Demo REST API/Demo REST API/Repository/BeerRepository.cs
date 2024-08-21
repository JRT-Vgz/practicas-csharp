using Demo_REST_API.DTOs;
using Demo_REST_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Demo_REST_API.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private BarContext _context;

        public BeerRepository(BarContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> Get() =>
            await _context.Beers.ToListAsync();

        public async Task<Beer> GetById(int id) =>
            await _context.Beers.FindAsync(id);

        public async Task Add(Beer beer) =>
            await _context.Beers.AddAsync(beer);


        public async void Update(Beer beer)
        {
            _context.Beers.Attach(beer);
            _context.Beers.Entry(beer).State = EntityState.Modified;
        }

        public void Delete(Beer beer) =>
            _context.Beers.Remove(beer);

        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
