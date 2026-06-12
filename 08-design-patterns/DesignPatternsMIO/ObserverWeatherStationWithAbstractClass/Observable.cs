using DesignPatternsMIO.ObserverWeatherStation.Interfaces;

namespace DesignPatternsMIO.ObserverWeatherStation
{
    public abstract class Observable
    {
        private List<IObserver> _observers;
        private bool _changed;

        public Observable()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o)
            => _observers.Add(o);

        public void RemoveObserver(IObserver o)
            => _observers.Remove(o);

        protected void NotifyObservers(Object arg)
        {
            if(_changed)
            {
                _observers.ForEach(o => o.Update(this, arg));
                _changed = false;
            }
        }

        protected void NotifyObservers()
            => NotifyObservers(null);

        protected void SetChanged() => _changed = true;
        protected void ClearChanged() => _changed = false;
        protected bool GetChanged() => _changed;
    }
}
