using EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 2-ApplicationLayer
{
    public interface IRepository
    {
        Task<IEnumerable<Beer>> GetAllAsync();
        Task<Beer> GetByIdAsync(int id);
        Task AddAsync(Beer beer);
    }
}
