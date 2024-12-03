
using _3_Data;
using _3_Repositories.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace _3_Repositories.QueryObjects
{
    public class BeerWithBrandQuery
    {
        private readonly AppDbContext _context;
        public BeerWithBrandQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerWithBrandResult>> GetAsync()
            => await _context.Beers.Join(
                _context.Brands,
                beer => beer.BrandId,
                brand => brand.Id,
                (beer, brand) => new BeerWithBrandResult
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Brand = brand.Name
                }).ToListAsync();
    }
}
