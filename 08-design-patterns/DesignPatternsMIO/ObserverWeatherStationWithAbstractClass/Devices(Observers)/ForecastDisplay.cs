using DesignPatternsMIO.ObserverWeatherStation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.ObserverWeatherStation.Devices_Observers_
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        
        private float _temperature;
        private Observable _weatherData;

        public ForecastDisplay(Observable weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(Observable observable, Object arg)
        {
            if (observable is WeatherData weatherData)
            {
                _temperature = weatherData.CurrentTemperature;
                Display();
            }
        }

        public void Display()
        {
            string message = _temperature switch
            {
                <= 0 => "Va a hacer muuuuucho frio.",
                < 20 => "Va a hacer frio.",
                < 25 => "Va a hacer bueno.",
                < 35 => "Va a hacer calor",
                >= 35 => "Va a hacer muuuuucho calor."
            };

            Console.WriteLine("ACTUALIZACIÓN DE FORECAST:");
            Console.WriteLine(message);
            Console.WriteLine();
        }      
    }
}
