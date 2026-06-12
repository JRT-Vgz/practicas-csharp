
namespace DesignPatternsMIO.ObserverWeatherStation
{
    public class WeatherData : Observable
    {
        private float _currentTemperature;
        private float _currentHumidity;
        private float _currentPressure;

        // SE HAN COMENTADO COSAS NO RELEVANTES PARA EL PATRON. SON SOLO EJEMPLOS DE COMO AJUSTAR CUANDO SOLTAR UNA NOTIFICACIÓN O NO.
        //private float _lastTemperatureNotified;
        //private float _lastHumidityNotified;
        //private float _lastPressureNotified;

        public float CurrentTemperature
        {
            get { return _currentTemperature; }
        }
        public float CurrentHumidity
        {
            get { return _currentHumidity; }
        }
        public float CurrentPressure
        {
            get { return _currentPressure; }
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _currentTemperature = temperature;
            _currentHumidity = humidity;
            _currentPressure = pressure;

            MeasurementsChanged();
        }

        public void MeasurementsChanged()
        {
            //if (hasMeasurementsChangedSignificantly())
            //{
                SetChanged();
                NotifyObservers();
                //UpdateLastMeasurementsNotified();
            //}
        }

        /* 
        private bool hasMeasurementsChangedSignificantly()
        {
            return hasTemperatureChangedSignificantly() 
                || hasHumidityChangedSignificantly()
                || hasPressureChangedSignificantly();
        }

        private bool hasTemperatureChangedSignificantly()
        {
            float temperatureChange = _currentTemperature - _lastTemperatureNotified;
            float absoluteTemperatureChange = Math.Abs(temperatureChange);

            if (absoluteTemperatureChange >= 5)
                return true;
            return false;
        }
        private bool hasHumidityChangedSignificantly()
        {
            float humidityChange = _currentHumidity - _lastHumidityNotified;
            float absoluteHumidityChange = Math.Abs(humidityChange);

            if (absoluteHumidityChange >= 5)
                return true;
            return false;
        }
        private bool hasPressureChangedSignificantly()
        {
            float pressureChange = _currentPressure - _lastPressureNotified;
            float absolutePressureChange = Math.Abs(pressureChange);

            if (absolutePressureChange >= 5)
                return true;
            return false;
        }

        private void UpdateLastMeasurementsNotified()
        {
            _lastTemperatureNotified = _currentTemperature;
            _lastHumidityNotified = _currentHumidity;
            _lastPressureNotified = _currentPressure;
        }
        */
    }
}
