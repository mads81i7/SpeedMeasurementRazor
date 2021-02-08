using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJsonLocation(List<Location> locations, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(locations, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }

        public static void WriteToJsonSpeedMeasurement(List<SpeedMeasurement> measurements, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(measurements, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
