
using _1_Entities;
using _2_Services;
using _3_Data;
using _3_Models;
using _3_Repositories.AdditionalDataClass;
using Microsoft.EntityFrameworkCore;

namespace _3_Repositories
{
    public class BeerRepository : IRepositoryAdditionalData<Beer, BeerAdditionalData>
    {
        private readonly AppDbContext _context;
        public BeerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
            => await _context.Beers.Select(b => new Beer
            {
                Id = b.Id,
                Name = b.Name,
                BrandId = b.BrandId,
                Alcohol = b.Alcohol
            }).ToListAsync();

        public async Task<Beer> GetByIdAsync(int id)
        {
            var beerModel = await _context.Beers.FindAsync(id);

            return new Beer 
            { 
                Id = beerModel.Id, 
                Name = beerModel.Name,
                BrandId = beerModel.BrandId,
                Alcohol = beerModel.Alcohol
            };
        }

        public async Task AddAsync(Beer beer, BeerAdditionalData beerAdditionalData)
        {
            var beerModel = new BeerModel 
            { 
                Name = beer.Name,
                BrandId = beer.Id,
                Alcohol = beer.Alcohol,  
                Description = beerAdditionalData.Description
            };

            await _context.Beers.AddAsync(beerModel);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Beer beer)
        {
            var beerModel = await _context.Beers.FindAsync(beer.Id);

            beerModel.Name = beer.Name;
            beerModel.BrandId = beer.BrandId;
            beerModel.Alcohol = beer.Alcohol;

            _context.Entry(beerModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var beerModel = await _context.Beers.FindAsync(id);

            _context.Beers.Remove(beerModel);
            await _context.SaveChangesAsync();
        }
    }
}
