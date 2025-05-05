using System;
using WeatherStationData;

namespace WeatherStationData.Tests
{
    [TestClass]
    public class WeatherStationTests
    {

        [TestMethod]
        public void Measure_CreatesMeasurement_AnalyzeReturnsForecast()
        {
            var station = new WeatherStation(
                DateTime.Now, "Berlin", "ID001", "Max", 100, "Nord");

            station.Measure();
            var warnings = station.Analyze();

            Assert.IsTrue(warnings.Count > 0);
            Assert.IsTrue(warnings[0].StartsWith("Forecast:"));
        }

        [TestMethod]
        public void Analyze_ReturnsEmptyList_IfNoMeasurement()
        {
            var station = new WeatherStation(
                DateTime.Now, "Berlin", "ID002", "Anna", 120, "Ost");

            var warnings = station.Analyze();

            Assert.AreEqual(0, warnings.Count);
        }

        [TestMethod]
        public void UpdateMeasurement_UsesCustomMeasurement_ForAnalysis()
        {
            var station = new WeatherStation(
                DateTime.Now, "Berlin", "ID003", "Paul", 80, "Süd");

            var m = new Measurement(80, 80, 35, 120, 9);
            station.UpdateMeasurement(m);

            var warnings = station.Analyze();

            Assert.IsTrue(warnings.Contains("Warning: Tornado Risk!"));
            Assert.IsTrue(warnings.Contains("Warning: Heatwave Risk!"));
            Assert.IsTrue(warnings.Contains("Warning: High UV Radiation!"));
        }
    }
}
