using _1_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public class GetPostUseCase
    {
        private readonly IExternalServiceAdapter<Post> _adapter;

        public GetPostUseCase(IExternalServiceAdapter<Post> adapter)
        {
            _adapter = adapter;
        }

        public async Task<IEnumerable<Post>> GetAllAsync() 
            => await _adapter.GetExternalDataAsync();
    }
}
