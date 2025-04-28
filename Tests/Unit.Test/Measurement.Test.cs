using System;
using WeatherStationData;

namespace Measurement.Tests
{
    [TestClass]
    public class MeasurementTests
    {
        [TestMethod]
        public void CalculateIGL_ReturnsTrue_WhenAirQualityIsHigh()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, 20, 120, 2);
            Assert.IsTrue(measurement.calculateIGL());
        }

        [TestMethod]
        public void CalculateIGL_ReturnsFalse_WhenAirQualityIsLow()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, 20, 80, 5);
            Assert.IsFalse(measurement.calculateIGL());
        }

        [TestMethod]
        public void CheckAvalancheRisk_ReturnsTrue_WhenConditionsAreMet()
        {
            var measurement = new WeatherStationData.Measurement(45, 85, -5, 50, 5);
            Assert.IsTrue(measurement.checkAvalancheRisk());
        }

        [TestMethod]
        public void CheckAvalancheRisk_ReturnsFalse_WhenConditionsAreNotMet()
        {
            var measurement = new WeatherStationData.Measurement(30, 70, 2, 50, 5);
            Assert.IsFalse(measurement.checkAvalancheRisk());
        }

        [TestMethod]
        public void ForecastWeather_ReturnsSunny_WhenHotAndDry()
        {
            var measurement = new WeatherStationData.Measurement(5, 40, 30, 50, 5);
            Assert.AreEqual("sunny", measurement.ForecastWeather());
        }

        [TestMethod]
        public void ForecastWeather_ReturnsSnowy_WhenColdAndHumid()
        {
            var measurement = new WeatherStationData.Measurement(5, 80, -5, 50, 5);
            Assert.AreEqual("snowy", measurement.ForecastWeather());
        }

        [TestMethod]
        public void ForecastWeather_ReturnsRainy_WhenVeryHumid()
        {
            var measurement = new WeatherStationData.Measurement(5, 90, 10, 50, 5);
            Assert.AreEqual("rainy", measurement.ForecastWeather());
        }

        [TestMethod]
        public void ForecastWeather_ReturnsChangeable_WhenNoSpecialCondition()
        {
            var measurement = new WeatherStationData.Measurement(5, 60, 15, 50, 5);
            Assert.AreEqual("Changeable weather", measurement.ForecastWeather());
        }

        [TestMethod]
        public void TornadoForecast_ReturnsTrue_WhenConditionsAreMet()
        {
            var measurement = new WeatherStationData.Measurement(80, 80, 25, 50, 5);
            Assert.IsTrue(measurement.tornadoForecast());
        }

        [TestMethod]
        public void TornadoForecast_ReturnsFalse_WhenConditionsAreNotMet()
        {
            var measurement = new WeatherStationData.Measurement(50, 60, 15, 50, 5);
            Assert.IsFalse(measurement.tornadoForecast());
        }

        [TestMethod]
        public void StormForecast_ReturnsTrue_WhenConditionsAreMet()
        {
            var measurement = new WeatherStationData.Measurement(60, 75, 15, 50, 5);
            Assert.IsTrue(measurement.stormForecast());
        }

        [TestMethod]
        public void StormForecast_ReturnsFalse_WhenConditionsAreNotMet()
        {
            var measurement = new WeatherStationData.Measurement(40, 65, 15, 50, 5);
            Assert.IsFalse(measurement.stormForecast());
        }

        [TestMethod]
        public void HeatwaveForecast_ReturnsTrue_WhenConditionsAreMet()
        {
            var measurement = new WeatherStationData.Measurement(10, 30, 35, 50, 8);
            Assert.IsTrue(measurement.heatwaveForecast());
        }

        [TestMethod]
        public void HeatwaveForecast_ReturnsFalse_WhenConditionsAreNotMet()
        {
            var measurement = new WeatherStationData.Measurement(10, 30, 25, 50, 5);
            Assert.IsFalse(measurement.heatwaveForecast());
        }

        [TestMethod]
        public void FrostForecast_ReturnsTrue_WhenTemperatureBelowZero()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, -2, 50, 5);
            Assert.IsTrue(measurement.frostForecast());
        }

        [TestMethod]
        public void FrostForecast_ReturnsFalse_WhenTemperatureAboveZero()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, 5, 50, 5);
            Assert.IsFalse(measurement.frostForecast());
        }

        [TestMethod]
        public void HighUVRisk_ReturnsTrue_WhenUVIndexIsHigh()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, 25, 50, 9);
            Assert.IsTrue(measurement.highUVRisk());
        }

        [TestMethod]
        public void HighUVRisk_ReturnsFalse_WhenUVIndexIsLow()
        {
            var measurement = new WeatherStationData.Measurement(10, 50, 25, 50, 5);
            Assert.IsFalse(measurement.highUVRisk());
        }
    }
}