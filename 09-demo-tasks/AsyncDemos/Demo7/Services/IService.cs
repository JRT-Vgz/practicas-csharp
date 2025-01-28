using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemos.Demo7.Services
{
    public interface IService
    {
        Task<List<Models.Amiibo>> GetAllData();
    }
}
