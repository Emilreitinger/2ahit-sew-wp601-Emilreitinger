using WeatherStationData;
using System;
using System.Collections.Generic;

namespace WeatherStationDataApp
{
    class WeatherStationApp
    {
        static void Main()
        {
            Console.WriteLine("Willkommen bei der Wetterstation!");

            Console.Write("Gib das Datum ein (JJJJ-MM-TT): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Gib den Standort ein: ");
            string location = Console.ReadLine()!;

            Console.Write("Gib die Stations-ID ein: ");
            string stationID = Console.ReadLine()!;

            Console.Write("Gib den Namen des Betreibers ein: ");
            string operatorName = Console.ReadLine()!;

            Console.Write("Gib die Höhe (in Metern) ein: ");
            double altitude = double.Parse(Console.ReadLine()!);

            Console.Write("Gib die Region ein: ");
            string region = Console.ReadLine()!;

            WeatherStation station = new WeatherStation(date, location, stationID, operatorName, altitude, region);

            Console.WriteLine("\nGib die Wettermessungen ein:");
            Console.Write("Windgeschwindigkeit (km/h): ");
            double windSpeed = double.Parse(Console.ReadLine()!);

            Console.Write("Luftfeuchtigkeit (%): ");
            double humidity = double.Parse(Console.ReadLine()!);

            Console.Write("Temperatur (°C): ");
            double temperature = double.Parse(Console.ReadLine()!);

            Console.Write("Luftqualität (AQI): ");
            double airQuality = double.Parse(Console.ReadLine()!);

            Console.Write("UV-Index: ");
            double uvIndex = double.Parse(Console.ReadLine()!);

            Measurement measurement = new Measurement(windSpeed, humidity, temperature, airQuality, uvIndex);
            station.UpdateMeasurement(measurement);

            List<string> warnings = station.Analyze();

            Console.WriteLine("\nWetteranalyse:");
            foreach (var warning in warnings)
            {
                Console.WriteLine(warning);
            }

            Console.WriteLine("\nDrücke eine Taste, um das Programm zu beenden...");
            Console.ReadKey();
        }
    }
}
