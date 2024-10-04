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
        #region Propiedades
        #endregion
        private readonly IExternalServiceAdapter<Post> _adapter;

        #region Constructor
        #endregion
        public GetPostUseCase(IExternalServiceAdapter<Post> adapter)
        {
            _adapter = adapter;
        }

        #region Metodos
        #endregion
        public async Task<IEnumerable<Post>> GetAllAsync() 
            => await _adapter.GetExternalDataAsync();
    }
}
