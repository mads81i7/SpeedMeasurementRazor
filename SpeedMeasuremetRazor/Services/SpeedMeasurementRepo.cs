using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class SpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private List<SpeedMeasurement> speedMeasurementsList;

        public SpeedMeasurementRepo()
        {
            speedMeasurementsList = MockData.Measurements;
        }
        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return speedMeasurementsList;
        }

        public void AddSpeedMeasurement(int speed, Location location, string image)
        {
            speedMeasurementsList.Add(new SpeedMeasurement()
            {
                Id = speedMeasurementsList.Count + 1,
                TimeStamp = DateTime.Now,
                Speed = speed,
                Location = location,
                Image = image
            });
        }

        public double AvarageSpeed()
        {
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
            for (int i = 0; i < speedMeasurementsList.Count; i++)
            {
                if (speedMeasurementsList[i].Id == id)
                {
                    speedMeasurementsList.Remove(speedMeasurementsList[i]);
                    break;
                }
            }

        }
    }
}
