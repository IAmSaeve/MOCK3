namespace webservice.Model
{
    public class Meassurement
    {
        public int Id { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string TimeStamp { get; set; }

        public Meassurement(int id, string pressure, string humidity, string temperature, string timeStamp)
        {
            Id = id;
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            TimeStamp = timeStamp;
        }
    }
}