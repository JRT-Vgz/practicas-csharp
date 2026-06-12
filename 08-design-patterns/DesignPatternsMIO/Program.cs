// See https://aka.ms/new-console-template for more information


//*****************************************************************************************************
// STRATEGY CHARACTER TEST
/*
using DesignPatternsMIO.StrategyCharacter;
using DesignPatternsMIO.StrategyCharacter.Weapon_Strategies;

List<AbstractCharacter> characters = [
    new Warrior(new AxeBehaviour()),
    new Archer(new BowBehaviour())
    ];

characters.ForEach(c => c.Attack());

DeathKnight deathKnight = new DeathKnight(new AxeBehaviour());
deathKnight.Attack();

deathKnight.WeaponBehaviour = new SwordBehaviour();
deathKnight.Attack();
*/
//*****************************************************************************************************



//*****************************************************************************************************
// OBSERVER WEATHER STATION TEST (CON INTERFACES)
/*
using DesignPatternsMIO.ObserverWeatherStationInterfaces;
using DesignPatternsMIO.ObserverWeatherStationInterfaces.Dispositivos;
using DesignPatternsMIO.ObserverWeatherStationWithInterfaces.DTOs;

WeatherDataSubject weatherDataSubject = new();
CurrentConditionsObserver currentConditionsObserver = new(weatherDataSubject);

weatherDataSubject.SetMeasurements(10, 15, 20);

// NOTIFICAR SIN DTO (LOS OBSERVADORES HACEN PULL DE LOS DATOS). ES MÁS CORRECTO
weatherDataSubject.NotifyObservers();

//NOTIFICAR CON DTO (EL SUJETO PUSHEA LOS DATOS A LOS OBSERVADORES)
WeatherDataDTO weatherDataDTO = new();
weatherDataDTO.temperature = weatherDataSubject.Temperature;
weatherDataDTO.humidity = weatherDataSubject.Humidity;
weatherDataDTO.pressure = weatherDataSubject.Pressure;

weatherDataSubject.NotifyObservers(weatherDataDTO);
*/
//*****************************************************************************************************




//*****************************************************************************************************
// OBSERVER WEATHER STATION TEST (CON CLASE ABSTRACTA)
/*
using DesignPatternsMIO.ObserverWeatherStation;
using DesignPatternsMIO.ObserverWeatherStation.Devices_Observers_;

WeatherData weatherData = new WeatherData();
CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

weatherData.SetMeasurements(10, 15, 20);
weatherData.SetMeasurements(35, 20, 18);
*/
//*****************************************************************************************************











