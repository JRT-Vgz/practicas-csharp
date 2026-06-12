using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.ObserverWeatherStationInterfaces.Interfaces
{
    public interface IObservador
    {
        void Update(ISujeto sujeto, Object dto);
    }
}
