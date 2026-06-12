
using DesignPatternsMIO.ObserverWeatherStationInterfaces.Interfaces;

namespace DesignPatternsMIO.ObserverWeatherStationInterfaces
{
    public class WeatherDataSubject : ISujeto
    {
        private List<IObservador> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public float Temperature
        {
            get { return _temperature; }
        }

        public float Humidity
        {
            get { return _humidity; }
        }

        public float Pressure
        {
            get { return _pressure; }
        }

        public WeatherDataSubject()
        {
            _observers = new List<IObservador>();
        }

        public void AddObserver(IObservador observer)
            => _observers.Add(observer);

        public void RemoveObserver(IObservador observer)
            => _observers.Remove(observer);

        public void NotifyObservers(Object dto)
            => _observers.ForEach(o => o.Update(this, dto));

        public void NotifyObservers()
            => NotifyObservers(null);

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        // METODO PARA CAMBIAR LOS PARAMETROS Y TESTEAR.
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            MeasurementsChanged();
        }
    }
}
