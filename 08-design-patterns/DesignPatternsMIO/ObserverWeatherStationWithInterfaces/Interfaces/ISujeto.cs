using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.ObserverWeatherStationInterfaces.Interfaces
{
    public interface ISujeto
    {
        void AddObserver(IObservador observer);
        void RemoveObserver(IObservador observer);
        void NotifyObservers(Object dto);
        void NotifyObservers();
    }
}
