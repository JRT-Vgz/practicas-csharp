using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Adapters
{
    public interface IExternalService<TDto>
    {
        public Task<IEnumerable<TDto>> GetServicesAsync();
    }
}
