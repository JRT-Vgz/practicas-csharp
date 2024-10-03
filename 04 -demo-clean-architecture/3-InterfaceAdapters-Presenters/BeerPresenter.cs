using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Presenters
{
    public class BeerPresenter : IPresenter<Beer, BeerViewModel>
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
        public IEnumerable<BeerViewModel> Present(IEnumerable<Beer> beers)
        {
            return beers.Select(b => new BeerViewModel
            {
                Id = b.Id,
                Name = "Cerveza: " + b.Name,
                Alcohol = b.Alcohol.ToString() + "%"
            });
        }
    }
}
