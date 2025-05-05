namespace WeatherStationData
{
    public class Measurement
    {
        private double _windSpeed;
        private double _humidity;
        private double _temperature;
        private double _airQuality;
        private double _uvIndex;

        public Measurement(double windSpeed, double humidity, double temperature, double airQuality, double uvIndex)
        {
            _windSpeed = windSpeed;
            _humidity = humidity;
            _temperature = temperature;
            _airQuality = airQuality;
            _uvIndex = uvIndex;
        }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double AirQuality { get; set;}
        public double UVIndex { get; set; }

        public bool calculateIGL() => _airQuality > 100;
        public bool checkAvalancheRisk() => _temperature < -1.0 && _humidity > 80.0 && _windSpeed > 40.0;
        public string ForecastWeather()
        {
            if (_temperature > 25 && _humidity < 50) return "sunny";
            if (_temperature < 0 && _humidity > 70) return "snowy";
            if (_humidity > 80) return "rainy";
            return "Changeable weather";
        }

        public bool tornadoForecast() => _windSpeed > 75 && _temperature > 20 && _humidity > 70;
        public bool stormForecast() => _windSpeed > 50 && _humidity > 70;
        public bool heatwaveForecast() => _temperature > 30 && _uvIndex > 7;
        public bool frostForecast() => _temperature < 0;
        public bool highUVRisk() => _uvIndex > 8;
    }
}