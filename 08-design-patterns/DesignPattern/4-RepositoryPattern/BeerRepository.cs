
using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern._4_RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DesignPatternsContext _context;
        public BeerRepository(DesignPatternsContext context)
        {
            _context = context;
        }

        public void Add(Beer beer)
            => _context.Beers.Add(beer);

        public void Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get()
            => _context.Beers.ToList();

        public Beer Get(int id)
            => _context.Beers.Find(id);

        public void Update(Beer beer)
            => _context.Entry(beer).State = EntityState.Modified;

        public void Save()
            => _context.SaveChanges();
    }
}
