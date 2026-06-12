using DesignPatternsMIO.ObserverWeatherStation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DesignPatternsMIO.ObserverWeatherStation.Devices_Observers_
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private Observable _weatherData;

        public CurrentConditionsDisplay(Observable weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(Observable observable, Object arg)
        {
            if (observable is WeatherData weatherData)
            {
                _temperature = weatherData.CurrentTemperature;
                _humidity = weatherData.CurrentHumidity;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine("ACTUALIZACIÓN DE CURRENT CONDITIONS:");
            Console.WriteLine($"Temperatura: {_temperature}; Humedad: {_humidity}.");
            Console.WriteLine();
        }
    }
}
