using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileWriter<T>
    {
        public static void WriteToJson(List<T> locations, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(locations, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}