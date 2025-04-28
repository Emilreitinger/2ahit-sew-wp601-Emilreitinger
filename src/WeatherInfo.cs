namespace WeatherStationData
{
    public class WeatherInfo
    {
        private string _name;
        private string _description;
        private Weather _weatherType;

        public WeatherInfo(string name, string description, Weather weatherType)
        {
            _name = name;
            _description = description;
            _weatherType = weatherType;
        }

        public string GetFullDescription()
        {
            return $"Wettername: {_name}\nBeschreibung: {_description}\nWettertyp: {_weatherType}";
        }
    }
}