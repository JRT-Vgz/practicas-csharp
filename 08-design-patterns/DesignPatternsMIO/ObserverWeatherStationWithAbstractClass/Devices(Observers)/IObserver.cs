using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.ObserverWeatherStation.Interfaces
{
    public interface IObserver
    {
        void Update(Observable observable, Object arg);
    }
}
