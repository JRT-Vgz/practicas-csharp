using DesignPatternsMIO.ObserverWeatherStationInterfaces.Interfaces;
using DesignPatternsMIO.ObserverWeatherStationWithInterfaces.DTOs;

namespace DesignPatternsMIO.ObserverWeatherStationInterfaces.Dispositivos
{
    public class CurrentConditionsObserver : IObservador, IDispositivo
    {
        private float _temperature;
        private float _humidity;
        private ISujeto _weatherDataSubject;

        public CurrentConditionsObserver(ISujeto weatherDataSubject)
        {
            _weatherDataSubject = weatherDataSubject;
            weatherDataSubject.AddObserver(this);
        }

        public void Update(Object dto)
        {
            if (dto == null)
            {
                Console.WriteLine("Se han obtenido los datos del Sujeto");
                _temperature = ((WeatherDataSubject)_weatherDataSubject).Temperature;
                _humidity = ((WeatherDataSubject)_weatherDataSubject).Humidity;
            }
            else
            {
                Console.WriteLine("Se han obtenido los datos del DTO");
                _temperature = ((WeatherDataDTO)dto).temperature;
                _humidity = ((WeatherDataDTO)dto).humidity;
            }
                Display();
        }

        public void Display()
        {
            Console.WriteLine("ACTUALIZACIÓN DE CURRENT CONDITIONS:");
            Console.WriteLine($"Temperatura: {_temperature}; Humedad: {_humidity}.");
            Console.WriteLine();
        }
    }
}
