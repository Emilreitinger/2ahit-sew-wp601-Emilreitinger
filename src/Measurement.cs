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
            if (windSpeed < 0)
            {
                throw new ArgumentException("Windgeschwindigkeit darf nicht negativ sein.", nameof(windSpeed));
            }

            if (humidity < 0 || humidity > 100)
            {
                throw new ArgumentException("Luftfeuchtigkeit muss zwischen 0 und 100 liegen.", nameof(humidity));
            }

            if (temperature < -100 || temperature > 100)
            {
                throw new ArgumentException("Temperatur muss zwischen -100 und 100 liegen.", nameof(temperature));
            }

            if (airQuality < 0)
            {
                throw new ArgumentException("Luftqualität darf nicht negativ sein.", nameof(airQuality));
            }

            if (uvIndex < 0)
            {
                throw new ArgumentException("UV-Index darf nicht negativ sein.", nameof(uvIndex));
            }
            _windSpeed = windSpeed;
            _humidity = humidity;
            _temperature = temperature;
            _airQuality = airQuality;
            _uvIndex = uvIndex;
        }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double AirQuality { get; set; }
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