namespace ArduinoSerialProject.Sensors
{
    public class TemperatureSensor
    {
        public double Value { get; private set; }

        public void UpdateFromString(string data)
        {
            // data 예: "TEMP:25.5"
            if (data.StartsWith("TEMP:"))
            {
                string val = data.Split(':')[1];
                if (double.TryParse(val, out double temp))
                {
                    Value = temp;
                }
            }
        }
    }
}
