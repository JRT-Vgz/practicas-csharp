using AsyncDemos.Demo7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemos.Demo7.Services
{
    public class FakeService : IService
    {
        public Task<List<Amiibo>> GetAllData()
        {
            List<Amiibo> amiibos = new List<Amiibo>
            {
                new Amiibo { name = "Mario", image = "https://fake.png"},
                new Amiibo { name = "Luigi", image = "https://fake.png"},
                new Amiibo { name = "Peach", image = "https://fake.png"},
                new Amiibo { name = "Yoshi", image = "https://fake.png"},
                new Amiibo { name = "Bowser", image = "https://fake.png"},
                new Amiibo { name = "Rosalina", image = "https://fake.png"},
            };
            return Task.FromResult(amiibos);
        }
    }
}
