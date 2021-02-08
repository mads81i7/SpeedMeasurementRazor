using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonSpeedMeasurementRepo: ISpeedMeasurementRepo
    {
        private string JsonFileName = @"Data\SpeedMeasurementData.json";
        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return JsonFileReader.ReadJsonSpeedMeasurement(JsonFileName);
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            throw new NotImplementedException();
        }

        public double AvarageSpeed()
        {
            throw new NotImplementedException();
        }

        public int NoOfOverSpeedLimit()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicense()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicenseForeach()
        {
            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            throw new NotImplementedException();
        }

        public void DeleteSpeedMeasurement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
