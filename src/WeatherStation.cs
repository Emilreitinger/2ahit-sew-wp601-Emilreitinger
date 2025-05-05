using System;

namespace WeatherStationData
{
    public class WeatherStation
    {
        private DateTime _date;
        private string _location;
        private string _stationID;
        private string _operatorName;
        private double _altitude;
        private string _region;
        private Measurement _currentMeasurement;

        public WeatherStation(DateTime date, string location, string stationID, string operatorName, double altitude, string region)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("Der Standort darf nicht null oder leer sein.", nameof(location));
            }

            if (string.IsNullOrEmpty(stationID))
            {
                throw new ArgumentException("Die Station-ID darf nicht null oder leer sein.", nameof(stationID));
            }
            _date = date;
            _location = location;
            _stationID = stationID;
            _operatorName = operatorName;
            _altitude = altitude;
            _region = region;
            _currentMeasurement = null!;
        }

        public void Measure()
        {
            double windSpeed = 30.0, humidity = 65.0, temperature = 22.5, airQuality = 50.0, uvIndex = 6.0;
            _currentMeasurement = new Measurement(windSpeed, humidity, temperature, airQuality, uvIndex);
        }

        public List<string> Analyze()
        {
            var warnings = new List<string>();

            if (_currentMeasurement == null) return warnings;

            string forecast = _currentMeasurement.ForecastWeather();
            warnings.Add($"Forecast: {forecast}");

            if (_currentMeasurement.tornadoForecast()) warnings.Add("Warning: Tornado Risk!");
            if (_currentMeasurement.stormForecast()) warnings.Add("Warning: Storm Risk!");
            if (_currentMeasurement.heatwaveForecast()) warnings.Add("Warning: Heatwave Risk!");
            if (_currentMeasurement.frostForecast()) warnings.Add("Warning: Frost Risk!");
            if (_currentMeasurement.highUVRisk()) warnings.Add("Warning: High UV Radiation!");
            return warnings;
        }

        public void UpdateMeasurement(Measurement m)
        {
            _currentMeasurement = m;
        }
    }
}