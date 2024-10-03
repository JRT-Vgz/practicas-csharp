using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public interface IMapper<TDto, TOutput>
    {
        public TOutput Map(TDto dto);
    }
}
