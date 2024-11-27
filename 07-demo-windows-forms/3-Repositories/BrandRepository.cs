using _1_Entities;
using _2_Services;
using _3_Data;
using _3_Models;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace _3_Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly AppDbContext _context;
        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
            => await _context.Brands.Select(b => new Brand
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToListAsync();

        public async Task<Brand> GetByIdAsync(int id)
        { 
            var brandModel = await _context.Brands.FindAsync(id);

            return new Brand { Id = brandModel.Id, Name = brandModel.Name };
        }

        public async Task AddAsync(Brand brand)
        {
            var brandModel = new BrandModel { Name = brand.Name };

            await _context.Brands.AddAsync(brandModel);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Brand brand)
        {
            var brandModel = await _context.Brands.FindAsync(brand.Id);

            brandModel.Name = brand.Name;

            _context.Entry(brandModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brandModel = await _context.Brands.FindAsync(id);

            _context.Brands.Remove(brandModel);
            await _context.SaveChangesAsync();
        }
    }
}
