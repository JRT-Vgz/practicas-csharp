using _1_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public interface IPresenter<TEntity, TOutput>
    {
        public IEnumerable<TOutput> Present(IEnumerable<TEntity> data);
    }
}
