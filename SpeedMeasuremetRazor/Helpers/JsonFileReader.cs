using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileReader
    {
        public static List<Location> ReadJsonLocation(string jsonName)
        {
            string jsonString = File.ReadAllText(jsonName);
            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }
        public static List<SpeedMeasurement> ReadJsonSpeedMeasurement(string jsonName)
        {
            string jsonString = File.ReadAllText(jsonName);
            return JsonSerializer.Deserialize<List<SpeedMeasurement>>(jsonString);
        }
    }
}
