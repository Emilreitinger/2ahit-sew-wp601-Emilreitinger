namespace WeatherStationData
{
    public class WeatherInfo
    {
        private string _name;
        private string _description;
        private Weather _weatherType;

        public WeatherInfo(string name, string description, Weather weatherType)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Der Name darf nicht null oder leer sein.", nameof(name));
            }
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