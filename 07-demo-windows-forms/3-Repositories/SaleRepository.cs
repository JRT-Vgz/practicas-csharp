
using _1_Entities;
using _2_Services;
using _3_Data;
using _3_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Repositories
{
    public class SaleRepository : IRepositorySimple<Sale>
    {
        private readonly AppDbContext _dbContext;
        public SaleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Sale sale)
        {
            var saleModel = new SaleModel();
            saleModel.Total = sale.Total;
            saleModel.CreationDate = sale.Date;
            saleModel.Concepts = sale.Concepts.Select(c => new ConceptModel
            {
                UnitPrice = c.UnitPrice,
                IdBeer = c.IdBeer,
                Quantity = c.Quantity,
            }).ToList();

            await _dbContext.Sales.AddAsync(saleModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
            => await _dbContext.Sales
            .Select(s => new Sale(s.Id, s.CreationDate,
                _dbContext.Concepts.Where(c => c.IdSale == s.Id)
                .Select(c => new Concept(c.Quantity, c.IdBeer, c.UnitPrice))
                .ToList())
            ).ToListAsync();
    }
}
