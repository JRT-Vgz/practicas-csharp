using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Presenters
{
    public class BeerDetailPresenter : IPresenter<Beer, BeerDetailViewModel>
    {
        public IEnumerable<BeerDetailViewModel> Present(IEnumerable<Beer> beers) 
            => beers.Select(b => new BeerDetailViewModel
            {
                Id = b.Id,
                Name = "Cerveza: " + b.Name,
                Alcohol = b.Alcohol + "%",
                Color = b.IsStrongBeer() ? "Red": "Green",
                Style = b.Style,
                Message = b.IsStrongBeer() ? "Cerveza fuerte": ""
            });
    }
}
