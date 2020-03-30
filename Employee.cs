namespace HealthInfo
{
    class Employee
    {
        public string Gin
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double BodyTemperature
        {
            get;
            set;
        }
        public bool HubeiTravelStatus
        {
            get;
            set;
        }
        public bool UnderTheWeather
        {
            get;
            set;
        }
        public Employee(string gin, string name, double bodyTemperature, bool hubeiTravelStatus, bool underTheWeather)
        {
            Gin = gin;
            Name = name;
            BodyTemperature = bodyTemperature;
            HubeiTravelStatus = hubeiTravelStatus;
            UnderTheWeather = underTheWeather;
        }
        public bool Alert()
        {
            if (BodyTemperature >= 37.3 || HubeiTravelStatus || UnderTheWeather)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}