using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Exceptions;
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
            return JsonFileReader<SpeedMeasurement>.ReadJson(JsonFileName);
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            if (speed <= 0 || speed > 300)
                throw new CalibrationException($"{speed} is an invalid speed.");

            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();

            speedMeasurementsList.Add(new SpeedMeasurement()
            {
                Id = GetHighestSpeedMeasurementId()+1,
                TimeStamp = DateTime.Now,
                Speed = speed,
                Location = location,
                Image = imageName
            });

            JsonFileWriter<SpeedMeasurement>.WriteToJson(speedMeasurementsList, JsonFileName);
        }

        public double AvarageSpeed()
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();
            double i = 0;

            foreach (SpeedMeasurement s in speedMeasurementsList)
            {
                i += s.Speed;

            }

            if (speedMeasurementsList.Count == 0)
                return -1;
            else
            {
                return i / speedMeasurementsList.Count;
            }
        }

        public int NoOfOverSpeedLimit()
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();
            int i = 0;

            foreach (SpeedMeasurement s in speedMeasurementsList)
            {
                if (s.Speed > s.Location.SpeedLimit)
                {
                    i++;
                }
            }

            return i;
        }

        public int NoOfCutInLicense()
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();

            int i = 0;
            foreach (SpeedMeasurement speedMeasurement in speedMeasurementsList)
            {
                if (speedMeasurement.Speed > 1.3 * speedMeasurement.Location.SpeedLimit)
                    i++;
            }

            return i;
        }

        public int NoOfCutInLicenseForeach()
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();

            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();

            int i = 0;
            foreach (SpeedMeasurement speedMeasurement in speedMeasurementsList)
            {
                if (speedMeasurement.Location.Zone == Zone.Motorvej)
                {
                    if (speedMeasurement.Speed > 1.3 * speedMeasurement.Location.SpeedLimit)
                        i++;
                }
                else
                {
                    if (speedMeasurement.Speed > 1.6 * speedMeasurement.Location.SpeedLimit)
                        i++;
                }
            }

            return i;
        }

        public void DeleteSpeedMeasurement(int id)
        {
            List<SpeedMeasurement> speedMeasurementsList = GetAllSpeedMeasurements();

            for (int i = 0; i < speedMeasurementsList.Count; i++)
            {
                if (speedMeasurementsList[i].Id == id)
                {
                    speedMeasurementsList.Remove(speedMeasurementsList[i]);
                    break;
                }
            }
            JsonFileWriter<SpeedMeasurement>.WriteToJson(speedMeasurementsList, JsonFileName);
        }

        public int GetHighestSpeedMeasurementId()
        {
            List<SpeedMeasurement> SpeedMeasurementsList = GetAllSpeedMeasurements();
            int maxId = 0;

            foreach (SpeedMeasurement speedMeasurement in SpeedMeasurementsList)
            {
                if (speedMeasurement.Id > maxId)
                    maxId = speedMeasurement.Id;
            }

            return maxId;
        }
    }
}
